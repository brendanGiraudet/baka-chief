namespace bakaChiefApplication.Services.ApiEndpointsService;

public interface IApiEndpointsService
{
    string GetByNamePathUrl(string name, int take, int skip);

    string CreatePathUrl();

    string DeletePathUrl(string id);

    string UpdatePathUrl(string id);

    string GetByIdPathUrl(string id);
}