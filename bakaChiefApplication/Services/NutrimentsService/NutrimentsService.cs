using System.Net.Http.Json;
using System.Text.Json.Serialization;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.NutrimentsService;

public class NutrimentsService : INutrimentsService
{
    private readonly HttpClient _httpClient;

    public NutrimentsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
    }

    public async Task<IEnumerable<Nutriment>> GetNutrimentsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<NutrimentResult>(NutrimentsApiEndpoints.GetNutrimentsPathUrl(10, 0));

        return response.Values;
    }
    
    public async Task<IEnumerable<Nutriment>> GetNutrimentsByNameAsync(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<NutrimentResult>(NutrimentsApiEndpoints.GetNutrimentsByNamePathUrl(10, 0, name));

        return response.Values;
    }
    
    public async Task<MethodResult<Nutriment>> CreateNutrimentAsync(Nutriment nutriment)
    {
        var response = await _httpClient.PostAsJsonAsync(NutrimentsApiEndpoints.CreateNutrimentPathUrl, nutriment);

        if(!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<Nutriment>.CreateFailedMethodResult("Creation Problem");
        }

        return MethodResultBuilder<Nutriment>.CreateSuccessMethodResult(nutriment);
    }
}
public class NutrimentResult
{
    [JsonPropertyName("@data.context")]
    public string Context { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public IEnumerable<Nutriment> Values { get; set; } = Enumerable.Empty<Nutriment>();
}