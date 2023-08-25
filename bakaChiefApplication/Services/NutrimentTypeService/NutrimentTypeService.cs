using bakaChiefApplication.Models;
using System.Net.Http.Json;

namespace bakaChiefApplication.Services.NutrimentTypeService
{
    public class NutrimentTypeService : INutrimentTypeService
    {
        private readonly HttpClient _httpClient;

        public NutrimentTypeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NutrimentTypeClient");
        }

        public async Task<List<NutrimentType>> GetAllNutrimentTypesAsync()
        {
            var nutrimentTypes = await _httpClient.GetFromJsonAsync<List<NutrimentType>>(NutrimentTypeApiEndpoints.GetAllNutrimentTypes);
            return nutrimentTypes;
        }

        public async Task<NutrimentType> GetNutrimentTypeByIdAsync(string id)
        {
            var nutrimentType = await _httpClient.GetFromJsonAsync<NutrimentType>(NutrimentTypeApiEndpoints.GetNutrimentTypeById(id));
            return nutrimentType;
        }

        public async Task<NutrimentType> CreateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            var response = await _httpClient.PostAsJsonAsync(NutrimentTypeApiEndpoints.CreateNutrimentType, nutrimentType);
            response.EnsureSuccessStatusCode();

            var createdNutrimentType = await response.Content.ReadFromJsonAsync<NutrimentType>();
            return createdNutrimentType;
        }

        public async Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            var response = await _httpClient.PutAsJsonAsync(NutrimentTypeApiEndpoints.UpdateNutrimentType(nutrimentType.Id), nutrimentType);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteNutrimentTypeAsync(string id)
        {
            var response = await _httpClient.DeleteAsync(NutrimentTypeApiEndpoints.DeleteNutrimentType(id));
            response.EnsureSuccessStatusCode();
        }
    }
}
