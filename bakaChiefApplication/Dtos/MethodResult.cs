namespace bakaChiefApplication.Dtos;

public class MethodResult<T>
{
    public string? ErrorMessage { get; set; }

    public bool IsSuccess() => string.IsNullOrEmpty(ErrorMessage);

    public T? Value { get; set; }
}

public static class MethodResultBuilder<T>
{
    public static MethodResult<T> CreateSuccessMethodResult(T value)
    {
        return new MethodResult<T>
        {
            Value = value
        };
    }
    public static MethodResult<T> CreateFailedMethodResult(string errorMessage)
    {
        return new MethodResult<T>
        {
            ErrorMessage = errorMessage
        };
    }
}