namespace bakaChiefApplication.Services.ApiEndpointsService;

public class NutrimentsApiEndpointsService : IApiEndpointsService
{
    public const string BasePathUrl = "/odata/Nutriments";

    public string GetNutrimentsPathUrl(int top, int skip) => $"{BasePathUrl}?$top={top}&$skip={skip}&$orderby=name";
   
    public string GetByNamePathUrl(string name, int top, int skip) => $"{GetNutrimentsPathUrl(top,skip)}&$filter=contains(tolower(name), '{name?.ToLower()}') eq true";

    public string CreatePathUrl() => BasePathUrl;
    
    public string DeletePathUrl(string id) => $"{BasePathUrl}/{id}";
    
    public string UpdatePathUrl(string id) => $"{BasePathUrl}/{id}";

    public string GetByIdPathUrl(string id) => $"{BasePathUrl}?$filter=id eq '{id}'";
}
