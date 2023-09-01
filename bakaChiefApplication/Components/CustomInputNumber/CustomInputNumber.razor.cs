using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace bakaChiefApplication.Components.CustomInputNumber
{
    public partial class CustomInputNumber
    {
        private bool _hasInitializedParameters;

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public int? Value { get; set; }

        [Parameter] public EventCallback<int?> ValueChanged { get; set; }

        [Parameter] public Expression<Func<int?>>? ValueExpression { get; set; }

        [CascadingParameter]
        public EditContext CascadedEditContext { get; set; }

        public EditContext EditContext { get; set; }

        protected internal FieldIdentifier FieldIdentifier { get; set; }

        protected int? CurrentValue
        {
            get => Value;
            set
            {
                var hasChanged = !EqualityComparer<int?>.Default.Equals(value, Value);
                if (hasChanged)
                {
                    Value = value;
                    _ = ValueChanged.InvokeAsync(Value);
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
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

                if (ValueExpression == null)
                {
                    throw new InvalidOperationException($"{nameof(CustomInputText)} requires a value for the 'ValueExpression' " +
                        $"parameter. Normally this is provided automatically when using 'bind-Value'.");
                }

                FieldIdentifier = FieldIdentifier.Create(ValueExpression);

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
