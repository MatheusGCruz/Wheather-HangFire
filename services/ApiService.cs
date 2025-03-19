using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly ConfigParameters _configParameters;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> FetchDataAsync(string city)
    {
        var response = await _httpClient.GetStringAsync("https://wttr.in/"+city+"?format=j1&lang=en");
        return response;
    }    public async Task<string> OpenWeatherDataAsync()
    {
        var response = await _httpClient.GetStringAsync("https://api.openweathermap.org/data/3.0/onecall?lat=-18.9230198&lon=-48.2267654&appid="+_configParameters._apiToken);
        return response;
    }



}
