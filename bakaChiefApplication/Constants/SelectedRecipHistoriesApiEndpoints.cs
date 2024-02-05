namespace bakaChiefApplication.Constants;

public static class SelectedRecipHistoriesApiEndpoints
{
    public const string BasePathUrl = "/odata/SelectedRecipHistories";

    public static string GetSelectedRecipHistoriesPathUrl(int top) => $"{BasePathUrl}?$top={top}&$orderby=date desc";

    public static string GenerateSelectedRecipHistoryPathUrl => BasePathUrl;

    public static string GetSelectedRecipHistoryByIdPathUrl(string id) => $"{BasePathUrl}?$filter=id eq '{id}'&$expand=Recips";
    
    public static string DeleteSelectedRecipHistoryPathUrl(string id) => $"{BasePathUrl}/{id}";
}