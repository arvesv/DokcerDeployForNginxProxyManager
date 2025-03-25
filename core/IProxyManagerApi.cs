
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
        var identity = "arve.svendsen@gmail.com";
        var secret = "GramSvendsen1";
        var requestBody = new
        {
            identity,
            secret
        };

        var jsonContent = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(requestBody),
            System.Text.Encoding.UTF8,
            "application/json"
        );
        var response = await _httpClient.PostAsync($"{_baseUrl}/api/tokens", jsonContent);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch token: {response.ReasonPhrase}");
        }

        var content = await response.Content.ReadAsStringAsync();


    }



    public async Task<bool> DoesServiceExist(string serviceName)
    {

        // First, get the bearer token
        GetBearerToken();

        var response = await _httpClient.GetAsync($"{_baseUrl}/api/services");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch services: {response.ReasonPhrase}");
        }

        var content = await response.Content.ReadAsStringAsync();
        return true;
    }

}
