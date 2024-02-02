namespace bakaChiefApplication.Constants;

public static class RecipTypesApiEndpoints
{
    public const string BasePathUrl = "/odata/RecipTypes";

    public static string GetRecipTypesPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=name";
   
    public static string GetRecipTypesByNamePathUrl(int top, int skip, string name) => $"{GetRecipTypesPathUrl(top,skip)}&$filter=contains(tolower(name), '{name?.ToLower()}') eq true";

    public static string CreateRecipTypePathUrl => BasePathUrl;
    
    public static string RemoveRecipTypePathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public static string UpdateRecipTypePathUrl(string id) => $"{BasePathUrl}/{id}";
}
