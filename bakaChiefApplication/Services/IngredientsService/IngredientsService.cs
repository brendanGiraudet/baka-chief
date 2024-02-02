using System.Net.Http.Json;
using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.IngredientsService;

public class IngredientsService : IIngredientsService
{
    private readonly HttpClient _httpClient;

    SearchConfiguration _searchConfiguration;

    public IngredientsService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        _searchConfiguration = searchConfigurationOptions.Value;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Ingredient>>(IngredientsApiEndpoints.GetIngredientsPathUrl(10, 0));

        return response.Value;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByNameAsync(string name, int? take = null, int? skip = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Ingredient>>(IngredientsApiEndpoints.GetIngredientsByNamePathUrl(take ?? _searchConfiguration.DefaultNumberOfItemsToTake, skip ?? _searchConfiguration.DefaultNumberOfItemsToSkip, name?.ToLower()));

        return response.Value;
    }

    public async Task<MethodResult<Ingredient>> CreateIngredientAsync(Ingredient ingredient)
    {
        var response = await _httpClient.PostAsJsonAsync(IngredientsApiEndpoints.CreateIngredientPathUrl, ingredient);

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<Ingredient>.CreateFailedMethodResult("Creation Problem");
        }

        return MethodResultBuilder<Ingredient>.CreateSuccessMethodResult(ingredient);
    }

    public async Task<MethodResult<string>> RemoveIngredientAsync(string IngredientIdToRemove)
    {
        var response = await _httpClient.DeleteAsync(IngredientsApiEndpoints.RemoveIngredientPathUrl(IngredientIdToRemove));

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");
        }

        return MethodResultBuilder<string>.CreateSuccessMethodResult(IngredientIdToRemove);
    }

    public async Task<MethodResult<Ingredient>> UpdateIngredientAsync(Ingredient ingredientToUpdate)
    {
        var response = await _httpClient.PutAsJsonAsync(IngredientsApiEndpoints.UpdateIngredientPathUrl(ingredientToUpdate.Id), ingredientToUpdate);

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<Ingredient>.CreateFailedMethodResult("Update Problem");
        }

        return MethodResultBuilder<Ingredient>.CreateSuccessMethodResult(ingredientToUpdate);
    }

    public async Task<MethodResult<Ingredient>> GetIngredientsByIdAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Ingredient>>(IngredientsApiEndpoints.GetIngredientsByIdPathUrl(id));

        if (response.Value == null || response.Value.Count() == 0)
        {
            return MethodResultBuilder<Ingredient>.CreateFailedMethodResult("Update Problem");
        }

        return MethodResultBuilder<Ingredient>.CreateSuccessMethodResult(response.Value.First());
    }
}