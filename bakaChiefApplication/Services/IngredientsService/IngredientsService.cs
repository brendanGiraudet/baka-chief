using bakaChiefApplication.Constants;
using bakaChiefApplication.Models;
using System.Net.Http.Json;

namespace bakaChiefApplication.Services.IngredientsService
{
    public class IngredientsService : IIngredientsService
    {
        private readonly HttpClient _httpClient;

        public IngredientsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientAsync()
        {
            var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>(IngredientsApiEndpoints.GetAllIngredient);
            return ingredients;
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            var ingredient = await _httpClient.GetFromJsonAsync<Ingredient>(IngredientsApiEndpoints.GetIngredientById(id));
            return ingredient;
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            var response = await _httpClient.PostAsJsonAsync(IngredientsApiEndpoints.CreateIngredient, ingredient);
            response.EnsureSuccessStatusCode();

            var createdIngredient = await response.Content.ReadFromJsonAsync<Ingredient>();
            return createdIngredient;
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            var response = await _httpClient.PutAsJsonAsync(IngredientsApiEndpoints.UpdateIngredient(ingredient.Id), ingredient);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteIngredientAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(IngredientsApiEndpoints.DeleteIngredient(id));
            response.EnsureSuccessStatusCode();
        }
    }
}
