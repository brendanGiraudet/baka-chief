using bakaChiefApplication.Configurations;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.ApiEndpointsService;
using bakaChiefApplication.Services.BaseService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.IngredientsService;

public class IngredientsService : BaseService<Ingredient>, IIngredientsService
{
    public IngredientsService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
        :base(httpClientFactory, searchConfigurationOptions, new IngredientsApiEndpointsService())
    {
        
    }
}