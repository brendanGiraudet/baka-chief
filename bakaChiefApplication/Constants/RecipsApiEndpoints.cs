namespace bakaChiefApplication.Constants;

public static class RecipsApiEndpoints
{
    public const string BasePathUrl = "/odata/Recips";

    public static string GetRecipsPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=name";
   
    public static string GetRecipsByNamePathUrl(int top, int skip, string name) => $"{GetRecipsPathUrl(top,skip)}&$filter=startswith(name, '{name}') eq true&$expand=RecipIngredients/Ingredient,RecipSteps";

    public static string CreateRecipPathUrl => BasePathUrl;
    
    public static string RemoveRecipPathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public static string UpdateRecipPathUrl(string id) => $"{BasePathUrl}/{id}";
}
