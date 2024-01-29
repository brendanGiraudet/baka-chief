using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace bakaChiefApplication.Components.CustomInputSelect;

public partial class CustomInputSelect<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputSelect<TValue>
{
    private readonly bool _isMultipleSelect;
    
    public CustomInputSelect()
    {
        _isMultipleSelect = typeof(TValue).IsArray;
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "input");

        AddInputTag(builder);

        AddErrorMessageTag(builder);

        builder.CloseElement();
    }

    private void AddInputTag(RenderTreeBuilder builder)
    {
         builder.OpenElement(2, "select");
        builder.AddMultipleAttributes(3, AdditionalAttributes);
        // builder.AddAttributeIfNotNullOrEmpty(4, "name", ValueExpression);
        builder.AddAttributeIfNotNullOrEmpty(5, "class", CssClass);
        builder.AddAttribute(6, "multiple", _isMultipleSelect);

        if (_isMultipleSelect)
        {
            builder.AddAttribute(7, "value", BindConverter.FormatValue(CurrentValue)?.ToString());
            builder.AddAttribute(8, "onchange", EventCallback.Factory.CreateBinder<string?[]?>(this, SetCurrentValueAsStringArray, default));
            builder.SetUpdatesAttributeName("value");
        }
        else
        {
            builder.AddAttribute(9, "value", CurrentValueAsString);
            builder.AddAttribute(10, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, default));
            builder.SetUpdatesAttributeName("value");
        }

        builder.AddElementReferenceCapture(11, __selectReference => Element = __selectReference);
        builder.AddContent(12, ChildContent);
        builder.CloseElement();
    }

     private void SetCurrentValueAsStringArray(string?[]? value)
    {
        CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
            ? result
            : default;
    }

    private void AddErrorMessageTag(RenderTreeBuilder builder)
    {
        var errorMessages = string.Join(" ", EditContext.GetValidationMessages(FieldIdentifier));
        builder.OpenElement(13, "div");
        builder.AddAttribute(14, "class", "validation-message");
        builder.AddContent(15, new MarkupString(errorMessages));
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