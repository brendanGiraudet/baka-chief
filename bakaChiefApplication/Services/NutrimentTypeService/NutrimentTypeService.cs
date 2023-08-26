using bakaChiefApplication.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Services.NutrimentTypeService
{
    public class NutrimentTypeService : INutrimentTypeService
    {
        private readonly HttpClient _httpClient;

        public NutrimentTypeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NutrimentTypeClient");
        }

        public async Task<IEnumerable<NutrimentType>> GetAllNutrimentTypesAsync()
        {
            var nutrimentTypes = await _httpClient.GetFromJsonAsync<IEnumerable<NutrimentType>>(NutrimentTypeApiEndpoints.GetAllNutrimentTypes, options: new System.Text.Json.JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
        });
            return nutrimentTypes;
        }

        public async Task<NutrimentType> GetNutrimentTypeByIdAsync(string id)
        {
            var nutrimentType = await _httpClient.GetFromJsonAsync<NutrimentType>(NutrimentTypeApiEndpoints.GetNutrimentTypeById(id));
            return nutrimentType;
        }

        public async Task<NutrimentType> CreateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            var response = await _httpClient.PostAsJsonAsync(NutrimentTypeApiEndpoints.CreateNutrimentType, nutrimentType, options: new System.Text.Json.JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            response.EnsureSuccessStatusCode();

            await Console.Out.WriteLineAsync(await response.Content.ReadAsStringAsync());

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
