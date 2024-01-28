using System.Net.Http.Json;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.IngredientsService;

public class IngredientsService : IIngredientsService
{
    private readonly HttpClient _httpClient;

    public IngredientsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Ingredient>>(IngredientsApiEndpoints.GetIngredientsPathUrl(10, 0));

        return response.Value;
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByNameAsync(string name, int take)
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Ingredient>>(IngredientsApiEndpoints.GetIngredientsByNamePathUrl(take, 0, name?.ToLower()));

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
}