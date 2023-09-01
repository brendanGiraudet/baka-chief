using bakaChiefApplication.Constants;
using bakaChiefApplication.Models;
using System.Net.Http.Json;

namespace bakaChiefApplication.Services.RecipsService
{
    public class RecipsService: IRecipsService
    {
        private readonly HttpClient _httpClient;

        public RecipsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        }

        public async Task<IEnumerable<Recip>> GetAllRecipsAsync()
        {
            var recips = await _httpClient.GetFromJsonAsync<IEnumerable<Recip>>(RecipApiEndpoints.GetAllRecip);
            return recips;
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            var ingredient = await _httpClient.GetFromJsonAsync<Recip>(RecipApiEndpoints.GetRecipById(id));
            return ingredient;
        }

        public async Task<Recip> CreateRecipAsync(Recip ingredient)
        {
            var response = await _httpClient.PostAsJsonAsync(RecipApiEndpoints.CreateRecip, ingredient);
            response.EnsureSuccessStatusCode();

            var createdRecip = await response.Content.ReadFromJsonAsync<Recip>();
            return createdRecip;
        }

        public async Task UpdateRecipAsync(Recip ingredient)
        {
            var response = await _httpClient.PutAsJsonAsync(RecipApiEndpoints.UpdateRecip(ingredient.Id), ingredient);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRecipAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(RecipApiEndpoints.DeleteRecip(id));
            response.EnsureSuccessStatusCode();
        }
    }
}