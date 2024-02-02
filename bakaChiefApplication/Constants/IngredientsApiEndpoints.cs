namespace bakaChiefApplication.Constants;

public static class IngredientsApiEndpoints
{
    public const string BasePathUrl = "/odata/Ingredients";

    public static string GetIngredientsPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=name";
   
    public static string GetIngredientsByNamePathUrl(int top, int skip, string name) => $"{GetIngredientsPathUrl(top,skip)}&$filter=contains(tolower(name), '{name?.ToLower()}') eq true&$expand=IngredientNutriments/Nutriment";

    public static string CreateIngredientPathUrl => BasePathUrl;
    
    public static string RemoveIngredientPathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public static string UpdateIngredientPathUrl(string id) => $"{BasePathUrl}/{id}";
}
