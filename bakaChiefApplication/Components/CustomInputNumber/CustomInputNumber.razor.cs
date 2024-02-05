using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace bakaChiefApplication.Components.CustomInputNumber;

public partial class CustomInputNumber<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputNumber<TValue>
{
    [Parameter] public string Label { get; set; } = string.Empty;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "input");

        AddInputTag(builder);

        AddLabelTag(builder);

        AddErrorMessageTag(builder);

        builder.CloseElement();
    }

    private void AddInputTag(RenderTreeBuilder builder)
    {
        builder.OpenElement(2, "input");
        builder.AddAttribute(3, "step", GetStepAttributeValue());
        builder.AddMultipleAttributes(4, base.AdditionalAttributes);
        builder.AddAttribute(5, "type", "number");
        builder.AddAttributeIfNotNullOrEmpty(6, "class", base.CssClass);
        builder.AddAttribute(7, "value", BindConverter.FormatValue(base.CurrentValueAsString));
        builder.AddAttribute(8, "onchange", EventCallback.Factory.CreateBinder<string>((object)this, (Action<string>)delegate (string __value)
        {
            base.CurrentValueAsString = __value;
        }, base.CurrentValueAsString ?? string.Empty, (CultureInfo?)null));
        builder.AddElementReferenceCapture(7, delegate (ElementReference __inputReference)
        {
            Element = __inputReference;
        });
        builder.CloseElement();
    }

    private void AddLabelTag(RenderTreeBuilder builder)
    {
        builder.OpenElement(9, "label");
        builder.AddContent(10, new MarkupString(Label));
        builder.CloseElement();
    }

    private void AddErrorMessageTag(RenderTreeBuilder builder)
    {
        var errorMessages = string.Join(" ", EditContext.GetValidationMessages(FieldIdentifier));
        builder.OpenElement(11, "div");
        builder.AddAttribute(12, "class", "validation-message");
        builder.AddContent(13, new MarkupString(errorMessages));
        builder.CloseElement();
    }

    private string GetStepAttributeValue()
    {
        Type type = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
        if (type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(float) || type == typeof(double) || type == typeof(decimal))
        {
            return "any";
        }

        throw new InvalidOperationException($"The type '{type}' is not a supported numeric type.");
    }
}

internal static class RenderTreeBuilderExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddAttributeIfNotNullOrEmpty(this RenderTreeBuilder builder, int sequence, string name, string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            builder.AddAttribute(sequence, name, value);
        }
    }
}