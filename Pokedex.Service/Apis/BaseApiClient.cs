using RestSharp;
using Pokedex.Service.Interfaces;

namespace Pokedex.Service.Apis;
public class BaseApiClient
{
    protected RestClient RestClient;

    readonly ILogService logService;

    public BaseApiClient(ILogService logService)
    {
        this.logService = logService;
    }

    HttpClient GetHttpClient()
    {
        return new HttpClient();
    }

    public void Initialize(string baseUrl)
    {
        var options = new RestClientOptions(baseUrl);
        RestClient = new RestClient(GetHttpClient(), options);
    }

}