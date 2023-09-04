using bakaChiefApplication.Constants;
using bakaChiefApplication.Models;
using System.Net.Http.Json;

namespace bakaChiefApplication.Services.NutrimentsService
{
    public class NutrimentsService : INutrimentsService
    {
        private readonly HttpClient _httpClient;

        public NutrimentsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        }

        public async Task<IEnumerable<Nutriment>> GetNutrimentsAsync()
        {
            var nutriments = await _httpClient.GetFromJsonAsync<IEnumerable<Nutriment>>(NutrimentsApiEndpoints.GetAllNutrimentTypes);

            return nutriments;
        }

        public async Task<Nutriment> GetNutrimentByIdAsync(string id)
        {
            var nutriment = await _httpClient.GetFromJsonAsync<Nutriment>(NutrimentsApiEndpoints.GetNutrimentTypeById(id));
            return nutriment;
        }

        public async Task<Nutriment> CreateNutrimentAsync(Nutriment nutriment)
        {
            var response = await _httpClient.PostAsJsonAsync(NutrimentsApiEndpoints.CreateNutrimentType, nutriment);
            response.EnsureSuccessStatusCode();

            var createdNutriment = await response.Content.ReadFromJsonAsync<Nutriment>();
            return createdNutriment;
        }

        public async Task UpdateNutrimentAsync(Nutriment nutriment)
        {
            var response = await _httpClient.PutAsJsonAsync(NutrimentsApiEndpoints.UpdateNutrimentType(nutriment.Id), nutriment);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteNutrimentAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(NutrimentsApiEndpoints.DeleteNutrimentType(id));
            response.EnsureSuccessStatusCode();
        }
    }
}
