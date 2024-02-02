namespace bakaChiefApplication.Constants;

public static class NutrimentsApiEndpoints
{
    public const string BasePathUrl = "/odata/Nutriments";

    public static string GetNutrimentsPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=name";
   
    public static string GetNutrimentsByNamePathUrl(int top, int skip, string name) => $"{GetNutrimentsPathUrl(top,skip)}&$filter=contains(tolower(name), '{name?.ToLower()}') eq true";

    public static string CreateNutrimentPathUrl => BasePathUrl;
    
    public static string RemoveNutrimentPathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public static string UpdateNutrimentPathUrl(string id) => $"{BasePathUrl}/{id}";

    public static string GetNutrimentsByIdPathUrl(string id) => $"{BasePathUrl}/{id}";
}
