using System.Net.Http.Json;
using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.RecipsService;

public class RecipsService : IRecipsService
{
    private readonly HttpClient _httpClient;

    SearchConfiguration _searchConfiguration;

    public RecipsService(IHttpClientFactory httpClientFactory, 
        IOptions<SearchConfiguration> SearchConfigurationOptions)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        _searchConfiguration = SearchConfigurationOptions.Value;
    }

    public async Task<IEnumerable<Recip>> GetRecipsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Recip>>(RecipsApiEndpoints.GetRecipsPathUrl(10, 0));

        return response.Value;
    }

    public async Task<IEnumerable<Recip>> GetRecipsByNameAsync(string name, int? take = null, int? skip = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Recip>>(RecipsApiEndpoints.GetRecipsByNamePathUrl(take ?? _searchConfiguration.DefaultNumberOfItemsToTake, skip ?? _searchConfiguration.DefaultNumberOfItemsToSkip, name));

        return response.Value;
    }

    public async Task<MethodResult<Recip>> CreateRecipAsync(Recip recip)
    {
        var response = await _httpClient.PostAsJsonAsync(RecipsApiEndpoints.CreateRecipPathUrl, recip);

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<Recip>.CreateFailedMethodResult("Creation Problem");
        }

        return MethodResultBuilder<Recip>.CreateSuccessMethodResult(recip);
    }

    public async Task<MethodResult<string>> RemoveRecipAsync(string RecipIdToRemove)
    {
        var response = await _httpClient.DeleteAsync(RecipsApiEndpoints.RemoveRecipPathUrl(RecipIdToRemove));

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");
        }

        return MethodResultBuilder<string>.CreateSuccessMethodResult(RecipIdToRemove);
    }

    public async Task<MethodResult<Recip>> UpdateRecipAsync(Recip recipToUpdate)
    {
        var response = await _httpClient.PutAsJsonAsync(RecipsApiEndpoints.UpdateRecipPathUrl(recipToUpdate.Id), recipToUpdate);

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<Recip>.CreateFailedMethodResult("Update Problem");
        }

        return MethodResultBuilder<Recip>.CreateSuccessMethodResult(recipToUpdate);
    }
}