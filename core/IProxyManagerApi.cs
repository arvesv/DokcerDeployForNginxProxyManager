
namespace core;
interface INginxProxyManagerApi
{
    Task<bool> DoesServiceExist(string serviceName);
}


public class NginxProxyManagerApi : INginxProxyManagerApi
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public NginxProxyManagerApi(string baseUrl)
    {
        _baseUrl = baseUrl;
        _httpClient = new HttpClient();
    }


    private async void GetBearerToken()
    {
        var response = await _httpClient.PostAsync($"{_baseUrl}/api/tokens", "{}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch token: {response.ReasonPhrase}");
        }

        var content = await response.Content.ReadAsStringAsync();

        return token;
    }



    public async Task<bool> DoesServiceExist(string serviceName)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/api/services");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch services: {response.ReasonPhrase}");
        }

        var content = await response.Content.ReadAsStringAsync();
        return true;
    }

}
