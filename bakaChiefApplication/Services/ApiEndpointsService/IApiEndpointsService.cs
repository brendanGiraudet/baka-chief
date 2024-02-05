namespace bakaChiefApplication.Services.ApiEndpointsService;

public interface IApiEndpointsService
{
    string GetByNamePathUrl(string name, int take, int skip);
}