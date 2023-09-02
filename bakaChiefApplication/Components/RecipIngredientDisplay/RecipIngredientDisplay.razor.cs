using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace bakaChiefApplication.Components.RecipIngredientDisplay
{
    public partial class RecipIngredientDisplay
    {
        private bool _hasInitializedParameters;

        [CascadingParameter]
        public EditContext CascadedEditContext { get; set; }

        public EditContext EditContext { get; set; }

        protected internal FieldIdentifier QuantityFieldIdentifier { get; set; }

        protected internal FieldIdentifier MeasureUnitFieldIdentifier { get; set; }

        [Parameter] public string IngredientName { get; set; }

        [Parameter] public int? Quantity { get; set; }

        [Parameter] public EventCallback<int?> QuantityChanged { get; set; }

        [Parameter] public Expression<Func<int?>>? QuantityExpression { get; set; }

        [Parameter] public string MeasureUnit { get; set; }

        [Parameter] public EventCallback<string> MeasureUnitChanged { get; set; }

        [Parameter] public Expression<Func<string>>? MeasureUnitExpression { get; set; }

        [Parameter] public bool IsAddable { get; set; } = false;

        [Parameter] public bool IsRemovable { get; set; } = false;

        [Parameter] public EventCallback OnclickCallback { get; set; }

        private async Task Onclick()
        {
            if (OnclickCallback.HasDelegate) await OnclickCallback.InvokeAsync();
        }

        protected int? CurrentQuantityValue
        {
            get => Quantity;
            set
            {
                var hasChanged = !EqualityComparer<int?>.Default.Equals(value, Quantity);
                if (hasChanged)
                {
                    Quantity = value;
                    _ = QuantityChanged.InvokeAsync(Quantity);
                    EditContext?.NotifyFieldChanged(QuantityFieldIdentifier);
                }
            }
        }
        
        protected string CurrentMeasureUnitValue
        {
            get => MeasureUnit;
            set
            {
                var hasChanged = !EqualityComparer<string>.Default.Equals(value, MeasureUnit);
                if (hasChanged)
                {
                    MeasureUnit = value;
                    _ = MeasureUnitChanged.InvokeAsync(MeasureUnit);
                    EditContext?.NotifyFieldChanged(MeasureUnitFieldIdentifier);
                }
            }
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (!_hasInitializedParameters)
            {
                // This is the first run
                // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

                if (QuantityExpression != null)
                {
                    QuantityFieldIdentifier = FieldIdentifier.Create(QuantityExpression);
                }
                
                if (MeasureUnitExpression != null)
                {
                    MeasureUnitFieldIdentifier = FieldIdentifier.Create(MeasureUnitExpression);
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
