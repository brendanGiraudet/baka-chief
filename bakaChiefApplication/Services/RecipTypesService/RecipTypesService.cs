using System.Net.Http.Json;
using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.RecipTypesService;

public class RecipTypesService : IRecipTypesService
{
    private readonly HttpClient _httpClient;
    
    SearchConfiguration _searchConfiguration;

    public RecipTypesService(IHttpClientFactory httpClientFactory,
        IOptions<SearchConfiguration> SearchConfigurationOptions)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        _searchConfiguration = SearchConfigurationOptions.Value;
    }

    public async Task<IEnumerable<RecipType>> GetRecipTypesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<RecipType>>(RecipTypesApiEndpoints.GetRecipTypesPathUrl(10, 0));

        return response.Value;
    }
    
    public async Task<IEnumerable<RecipType>> GetRecipTypesByNameAsync(string name, int? take = null, int? skip = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<RecipType>>(RecipTypesApiEndpoints.GetRecipTypesByNamePathUrl(take ?? _searchConfiguration.DefaultNumberOfItemsToTake, skip ?? _searchConfiguration.DefaultNumberOfItemsToSkip, name));

        return response.Value;
    }
    
    public async Task<MethodResult<RecipType>> CreateRecipTypeAsync(RecipType RecipType)
    {
        var response = await _httpClient.PostAsJsonAsync(RecipTypesApiEndpoints.CreateRecipTypePathUrl, RecipType);

        if(!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<RecipType>.CreateFailedMethodResult("Creation Problem");
        }

        return MethodResultBuilder<RecipType>.CreateSuccessMethodResult(RecipType);
    }
    
    public async Task<MethodResult<string>> RemoveRecipTypeAsync(string RecipTypeIdToRemove)
    {
        var response = await _httpClient.DeleteAsync(RecipTypesApiEndpoints.RemoveRecipTypePathUrl(RecipTypeIdToRemove));

        if(!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");
        }

        return MethodResultBuilder<string>.CreateSuccessMethodResult(RecipTypeIdToRemove);
    }

    public async Task<MethodResult<RecipType>> UpdateRecipTypeAsync(RecipType RecipTypeToUpdate)
    {
        var response = await _httpClient.PutAsJsonAsync(RecipTypesApiEndpoints.UpdateRecipTypePathUrl(RecipTypeToUpdate.Id), RecipTypeToUpdate);

        if(!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<RecipType>.CreateFailedMethodResult("Update Problem");
        }

        return MethodResultBuilder<RecipType>.CreateSuccessMethodResult(RecipTypeToUpdate);
    }
}