namespace bakaChiefApplication.Services.ApiEndpointsService;

public class RecipsApiEndpointsService : IApiEndpointsService
{
    public const string BasePathUrl = "/odata/Recips";

    public string GetRecipsPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=name";
   
    public string GetByNamePathUrl(string name, int top, int skip) => $"{GetRecipsPathUrl(top,skip)}&$filter=contains(tolower(name), '{name?.ToLower()}') eq true";

    public string CreatePathUrl() => BasePathUrl;
    
    public string DeletePathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public string UpdatePathUrl(string id) => $"{BasePathUrl}/{id}";

    public string GetByIdPathUrl(string id) => $"{BasePathUrl}?$filter=id eq '{id}'&$expand=RecipIngredients/Ingredient&$expand=RecipIngredients/MeasureUnit";
}