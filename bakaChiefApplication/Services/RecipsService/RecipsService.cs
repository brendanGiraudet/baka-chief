using bakaChiefApplication.Configurations;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.ApiEndpointsService;
using bakaChiefApplication.Services.BaseService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.RecipsService;

public class RecipsService : BaseService<Recip>, IRecipsService
{
    public RecipsService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
        :base(httpClientFactory, searchConfigurationOptions, new RecipsApiEndpointsService())
    {
        
    }
}