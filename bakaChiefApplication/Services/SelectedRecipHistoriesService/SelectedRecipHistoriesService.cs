using bakaChiefApplication.Configurations;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.ApiEndpointsService;
using bakaChiefApplication.Services.BaseService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.SelectedRecipHistoriesService;

public class SelectedRecipHistoriesService : BaseService<SelectedRecipHistory>, ISelectedRecipHistoriesService
{
    public SelectedRecipHistoriesService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
        : base(httpClientFactory, searchConfigurationOptions, new SelectedRecipHistoriesApiEndpointsService())
    {

    }
}