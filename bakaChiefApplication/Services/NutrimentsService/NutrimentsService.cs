using bakaChiefApplication.Configurations;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.ApiEndpointsService;
using bakaChiefApplication.Services.BaseService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.NutrimentsService;

public class NutrimentsService : BaseService<Nutriment>, INutrimentsService
{
    public NutrimentsService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
        :base(httpClientFactory, searchConfigurationOptions, new NutrimentsApiEndpointsService())
    {
        
    }
}