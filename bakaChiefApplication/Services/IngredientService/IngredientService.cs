using bakaChiefApplication.Constants;
using bakaChiefApplication.Models;
using bakaChiefApplication.Services.IngredientService;
using System.Net.Http.Json;

namespace bakaChiefApplication.Services.NutrimentTypeService
{
    public class IngredientService : IIngredientService
    {
        private readonly HttpClient _httpClient;

        public IngredientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientAsync()
        {
            var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>(IngredientApiEndpoints.GetAllIngredient);
            return ingredients;
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            var ingredient = await _httpClient.GetFromJsonAsync<Ingredient>(IngredientApiEndpoints.GetIngredientById(id));
            return ingredient;
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            var response = await _httpClient.PostAsJsonAsync(IngredientApiEndpoints.CreateIngredient, ingredient);
            response.EnsureSuccessStatusCode();

            var createdIngredient = await response.Content.ReadFromJsonAsync<Ingredient>();
            return createdIngredient;
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            var response = await _httpClient.PutAsJsonAsync(IngredientApiEndpoints.UpdateIngredient(ingredient.Id), ingredient);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteIngredientAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(IngredientApiEndpoints.DeleteIngredient(id));
            response.EnsureSuccessStatusCode();
        }
    }
}
