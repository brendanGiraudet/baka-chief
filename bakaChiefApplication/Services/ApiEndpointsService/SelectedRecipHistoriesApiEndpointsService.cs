namespace bakaChiefApplication.Services.ApiEndpointsService;

public class SelectedRecipHistoriesApiEndpointsService : IApiEndpointsService
{
    public const string BasePathUrl = "/odata/SelectedRecipHistories";

    public string GetSelectedRecipHistoriesPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=date desc";
   
    public string GetByNamePathUrl(string name, int top, int skip) => $"{GetSelectedRecipHistoriesPathUrl(top,skip)}";

    public string CreatePathUrl() => BasePathUrl;
    
    public string DeletePathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public string UpdatePathUrl(string id) => $"{BasePathUrl}/{id}";

    public string GetByIdPathUrl(string id) => $"{BasePathUrl}?$filter=id eq '{id}'&$expand=Recips($expand=RecipIngredients/Ingredient)&$expand=Recips($expand=RecipIngredients/MeasureUnit)";
}