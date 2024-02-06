using bakaChiefApplication.Configurations;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.ApiEndpointsService;
using bakaChiefApplication.Services.BaseService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.MeasureUnitsService;

public class MeasureUnitsService : BaseService<MeasureUnit>, IMeasureUnitsService
{
    public MeasureUnitsService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
        :base(httpClientFactory, searchConfigurationOptions, new MeasureUnitsApiEndpointsService())
    {
        
    }
}