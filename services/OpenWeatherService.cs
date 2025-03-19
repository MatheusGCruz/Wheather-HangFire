using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherSystem_HangfireWorker;

public class OpenWeatherService
{
    private readonly ApiService _apiService;
    private readonly DatabaseService _databaseService;

    public OpenWeatherService(ApiService apiService, DatabaseService databaseService)
    {
        _apiService = apiService;
        _databaseService = databaseService;
    }

    public async Task FetchAndSaveDataAsync(){
        try
        {
            string data = await _apiService.OpenWeatherDataAsync();

            OpenWeatherObject openWeatherObject = JsonConvert.DeserializeObject<OpenWeatherObject>(data);
            var openWeatherCurrent = openWeatherObject.current;
            CurrentCondition currentCondition = new CurrentCondition();

            if(openWeatherCurrent != null){
                currentCondition.cloudcover = openWeatherCurrent.clouds;
                currentCondition.uvIndex = openWeatherCurrent.uvi;     
                currentCondition.visibility = openWeatherCurrent.visibility;
                currentCondition.windspeedKmph = openWeatherCurrent.wind_speed;
                currentCondition.winddirDegree = openWeatherCurrent.wind_deg;
                currentCondition.pressure = openWeatherCurrent.pressure;
                currentCondition.observation_time = DateTime.UnixEpoch.AddSeconds(openWeatherCurrent.dt+10);
                currentCondition.localObsDateTime = DateTime.UnixEpoch.AddSeconds(openWeatherCurrent.dt + openWeatherCurrent.timezone_offset+10);
                currentCondition.FeelsLikeC = Convert.ToInt32(openWeatherCurrent.feels_like - 271.15);
                currentCondition.temp_C = Convert.ToInt32(openWeatherCurrent.temp - 271.15);
                currentCondition.temp_F =  currentCondition.temp_C*9/5 + 32;
                currentCondition.FeelsLikeF = currentCondition.FeelsLikeF*9/5 + 32;
                currentCondition.humidity = openWeatherCurrent.humidity;

                currentCondition.city = "Uberlandia";
                currentCondition.country = "Brazil";

                await _databaseService.SaveCurrentConditionAsync(currentCondition);
                Console.WriteLine($"[Job] Current valid condition: {currentCondition.localObsDateTime}");
            }  

            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Job Error] {ex.Message}");
        }
    }
}
