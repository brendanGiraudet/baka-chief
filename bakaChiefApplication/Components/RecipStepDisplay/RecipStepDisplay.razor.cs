using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace bakaChiefApplication.Components.RecipStepDisplay
{
    public partial class RecipStepDisplay
    {
        private bool _hasInitializedParameters;
        [Parameter] public int? Number { get; set; }
        [Parameter] public EventCallback<int?> NumberChanged { get; set; }
        [Parameter] public Expression<Func<int?>>? NumberExpression { get; set; }
        protected internal FieldIdentifier NumberFieldIdentifier { get; set; }
        protected int? CurrentNumberValue
        {
            get => Number;
            set
            {
                var hasChanged = !EqualityComparer<int?>.Default.Equals(value, Number);
                if (hasChanged)
                {
                    Number = value;
                    _ = NumberChanged.InvokeAsync(Number);
                    EditContext?.NotifyFieldChanged(NumberFieldIdentifier);
                }
            }
        }

        [Parameter] public string Description { get; set; }
        [Parameter] public EventCallback<string> DescriptionChanged { get; set; }
        [Parameter] public Expression<Func<string>>? DescriptionExpression { get; set; }
        protected internal FieldIdentifier DescriptionFieldIdentifier { get; set; }
        protected string CurrentDescriptionValue
        {
            get => Description;
            set
            {
                var hasChanged = !EqualityComparer<string>.Default.Equals(value, Description);
                if (hasChanged)
                {
                    Description = value;
                    _ = DescriptionChanged.InvokeAsync(Description);
                    EditContext?.NotifyFieldChanged(DescriptionFieldIdentifier);
                }
            }
        }

        [Parameter] public EventCallback OnclickCallback { get; set; }
        [Parameter] public bool IsAddable { get; set; }
        [Parameter] public bool IsRemovable { get; set; }

        [CascadingParameter] public EditContext CascadedEditContext { get; set; }

        public EditContext EditContext { get; set; }

        private async Task Onclick()
        {
            if(OnclickCallback.HasDelegate)await OnclickCallback.InvokeAsync();
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (!_hasInitializedParameters)
            {
                // This is the first run
                // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

                if (NumberExpression != null)
                {
                    NumberFieldIdentifier = FieldIdentifier.Create(NumberExpression);
                }

                if (DescriptionExpression != null)
                {
                    DescriptionFieldIdentifier = FieldIdentifier.Create(DescriptionExpression);
                }

                if (CascadedEditContext != null)
                {
                    EditContext = CascadedEditContext;
                }

                _hasInitializedParameters = true;
            }
            else if (CascadedEditContext != EditContext)
            {
                // Not the first run

                // We don't support changing EditContext because it's messy to be clearing up state and event
                // handlers for the previous one, and there's no strong use case. If a strong use case
                // emerges, we can consider changing this.
                throw new InvalidOperationException($"{this.GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterView.Empty);
        }
    }
}
