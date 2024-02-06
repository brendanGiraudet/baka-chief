using bakaChiefApplication.Configurations;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.ApiEndpointsService;
using bakaChiefApplication.Services.BaseService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.RecipTypesService;

public class RecipTypesService : BaseService<RecipType>, IRecipTypesService
{
    public RecipTypesService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
        :base(httpClientFactory, searchConfigurationOptions, new RecipTypesApiEndpointsService())
    {
        
    }
}