using System.Net.Http.Json;
using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Services.NutrimentsService;

public class NutrimentsService : INutrimentsService
{
    private readonly HttpClient _httpClient;

    SearchConfiguration _searchConfiguration;

    public NutrimentsService(IHttpClientFactory httpClientFactory, IOptions<SearchConfiguration> searchConfigurationOptions)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
        _searchConfiguration = searchConfigurationOptions.Value;
    }

    public async Task<IEnumerable<Nutriment>> GetNutrimentsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Nutriment>>(NutrimentsApiEndpoints.GetNutrimentsPathUrl(10, 0));

        return response.Value;
    }
    
    public async Task<IEnumerable<Nutriment>> GetNutrimentsByNameAsync(string name, int? take = null, int? skip = null)
    {
        System.Console.WriteLine("take " + take);
        System.Console.WriteLine("take " + _searchConfiguration.DefaultNumberOfItemsToTake);
        var response = await _httpClient.GetFromJsonAsync<ODataResult<Nutriment>>(NutrimentsApiEndpoints.GetNutrimentsByNamePathUrl(take ?? _searchConfiguration.DefaultNumberOfItemsToTake, skip ?? _searchConfiguration.DefaultNumberOfItemsToSkip, name));

        return response.Value;
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
    
    public async Task<MethodResult<string>> RemoveNutrimentAsync(string nutrimentIdToRemove)
    {
        var response = await _httpClient.DeleteAsync(NutrimentsApiEndpoints.RemoveNutrimentPathUrl(nutrimentIdToRemove));

        if(!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");
        }

        return MethodResultBuilder<string>.CreateSuccessMethodResult(nutrimentIdToRemove);
    }

    public async Task<MethodResult<Nutriment>> UpdateNutrimentAsync(Nutriment nutrimentToUpdate)
    {
        var response = await _httpClient.PutAsJsonAsync(NutrimentsApiEndpoints.UpdateNutrimentPathUrl(nutrimentToUpdate.Id), nutrimentToUpdate);

        if(!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<Nutriment>.CreateFailedMethodResult("Update Problem");
        }

        return MethodResultBuilder<Nutriment>.CreateSuccessMethodResult(nutrimentToUpdate);
    }
}