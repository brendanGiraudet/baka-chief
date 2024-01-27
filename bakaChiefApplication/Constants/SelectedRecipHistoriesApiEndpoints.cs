namespace bakaChiefApplication.Constants;

public static class SelectedRecipHistoriesApiEndpoints
{
    public const string BasePathUrl = "/odata/SelectedRecipHistories";

    public static string GetSelectedRecipHistoriesPathUrl(int top) => $"{BasePathUrl}?$top={top}&$orderby=date desc&$expand=Recips";

    public static string GenerateSelectedRecipHistoryPathUrl => BasePathUrl;
}