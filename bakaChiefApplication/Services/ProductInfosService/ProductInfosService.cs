using System.Net.Http.Json;
using System.Text.Json.Serialization;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.ProductInfosService;

public class ProductInfosService : IProductInfosService
{
    private readonly HttpClient _httpClient;

    public ProductInfosService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
    }

    public async Task<IEnumerable<ProductInfo>> GetProductsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<TestProduct>(ProductInfosApiEndpoints.GetProductInfosUrl(10,0));

        System.Console.WriteLine($"service prd : {response.Values?.Count()}");

        return response.Values;
    }
}
public class TestProduct
    {
        [JsonPropertyName("@data.context")]
        public string Context { get; set; }

        [JsonPropertyName("value")]
        public IEnumerable<ProductInfo> Values { get; set; }
    }