using System.Net.Http.Json;
using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Services.ApiEndpointsService;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.BaseService;

public class BaseService<T>
{
    private readonly HttpClient _httpClient;

    private readonly SearchConfiguration _searchConfiguration;

    private readonly IApiEndpointsService _apiEndpointsService;

    public BaseService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions, IApiEndpointsService apiEndpointsService)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        _searchConfiguration = searchConfigurationOptions.Value;
        _apiEndpointsService = apiEndpointsService;
    }

    /// <inheritdoc/>
    public async Task<MethodResult<IEnumerable<T>>> GetByNameAsync(string name, int? take = null, int? skip = null)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<ODataResult<T>>(_apiEndpointsService.GetByNamePathUrl(name?.ToLower() ?? string.Empty, take ?? _searchConfiguration.DefaultNumberOfItemsToTake, skip ?? _searchConfiguration.DefaultNumberOfItemsToSkip));

            if (response == null) return MethodResultBuilder<IEnumerable<T>>.CreateFailedMethodResult("Get by name Problem");

            return MethodResultBuilder<IEnumerable<T>>.CreateSuccessMethodResult(response.Value);

        }
        catch (System.Exception)
        {
            return MethodResultBuilder<IEnumerable<T>>.CreateFailedMethodResult("Get by name Problem");
        }

    }

    /// <inheritdoc/>
    public async Task<MethodResult<T>> GetByIdAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<T>>(IngredientsApiEndpoints.GetIngredientsByIdPathUrl(id));

        if (response == null || response.Value == null || response.Value.Count() == 0)
        {
            return MethodResultBuilder<T>.CreateFailedMethodResult("Get by id Problem");
        }

        return MethodResultBuilder<T>.CreateSuccessMethodResult(response.Value.First());
    }

    /// <inheritdoc/>
    public async Task<MethodResult<T>> CreateAsync(T item)
    {
        var response = await _httpClient.PostAsJsonAsync(IngredientsApiEndpoints.CreateIngredientPathUrl, item);

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<T>.CreateFailedMethodResult("Creation Problem");
        }

        return MethodResultBuilder<T>.CreateSuccessMethodResult(item);
    }

    /// <inheritdoc/>
    public async Task<MethodResult<string>> DeleteAsync(string itemIdToDelete)
    {
        var response = await _httpClient.DeleteAsync(IngredientsApiEndpoints.RemoveIngredientPathUrl(itemIdToDelete));

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");
        }

        return MethodResultBuilder<string>.CreateSuccessMethodResult(itemIdToDelete);
    }

    /// <inheritdoc/>
    public async Task<MethodResult<T>> UpdateAsync(string id, T itemToUpdate)
    {
        var response = await _httpClient.PutAsJsonAsync(IngredientsApiEndpoints.UpdateIngredientPathUrl(id), itemToUpdate);

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<T>.CreateFailedMethodResult("Update Problem");
        }

        return MethodResultBuilder<T>.CreateSuccessMethodResult(itemToUpdate);
    }
}