using System.Net.Http.Json;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.SelectedRecipHistoriesService;

public class SelectedRecipHistoriesService : ISelectedRecipHistoriesService
{
    private readonly HttpClient _httpClient;

    public SelectedRecipHistoriesService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(NameHttpClient.BakaChiefAPI);
    }

    public async Task<MethodResult<IEnumerable<SelectedRecipHistory>>> GetSelectedRecipHistoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<ODataResult<SelectedRecipHistory>>(SelectedRecipHistoriesApiEndpoints.GetSelectedRecipHistoriesPathUrl(10));

            return MethodResultBuilder<IEnumerable<SelectedRecipHistory>>.CreateSuccessMethodResult(response.Value);
        }
        catch (System.Exception)
        {
            return MethodResultBuilder<IEnumerable<SelectedRecipHistory>>.CreateFailedMethodResult("Selection Problem");
        }
    }

    public async Task<MethodResult<SelectedRecipHistory>> GenerateSelectedRecipHistoriesAsync()
    {
        var response = await _httpClient.PostAsJsonAsync(SelectedRecipHistoriesApiEndpoints.GenerateSelectedRecipHistoryPathUrl, new SelectedRecipHistory());

        if (!response.IsSuccessStatusCode)
        {
            return MethodResultBuilder<SelectedRecipHistory>.CreateFailedMethodResult("Generation Problem");
        }

        return MethodResultBuilder<SelectedRecipHistory>.CreateSuccessMethodResult(new SelectedRecipHistory());
    }

    public async Task<MethodResult<SelectedRecipHistory>> GetSelectedRecipHistoryByIdAsync(string id)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<ODataResult<SelectedRecipHistory>>(SelectedRecipHistoriesApiEndpoints.GetSelectedRecipHistoryByIdPathUrl(id));

            return MethodResultBuilder<SelectedRecipHistory>.CreateSuccessMethodResult(response.Value.FirstOrDefault());
        }
        catch (System.Exception)
        {
            return MethodResultBuilder<SelectedRecipHistory>.CreateFailedMethodResult("Selection Problem");
        }
    }
    
    public async Task<MethodResult<string>> RemoveSelectedRecipHistoryAsync(string id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(SelectedRecipHistoriesApiEndpoints.DeleteSelectedRecipHistoryPathUrl(id));

            if(!response.IsSuccessStatusCode) return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");

            return MethodResultBuilder<string>.CreateSuccessMethodResult(id);
        }
        catch (System.Exception)
        {
            return MethodResultBuilder<string>.CreateFailedMethodResult("Delete Problem");
        }
    }
}