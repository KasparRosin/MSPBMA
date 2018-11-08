using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class Core
    {
        
        public static async Task<Forecast> getForecast(string cityName)
        {
            string key = "294503193ad5ff89e94382e08c7a13b2";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&APPID=" + key + "&units=metric";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Forecast
            {
                minTemperature = (string)results["main"]["temp_min"],
                maxTemperature = (string)results["main"]["temp_max"],
                Humidity = (string)results["main"]["humidity"],
                Description = (string)results["weather"][0]["main"],
                Wind = (string)results["wind"]["speed"],
                Icon = (string)results["weather"][0]["icon"]
            };
            return weather;
        }

        public static async Task<List<Forecast>>GetWeekForecast(string InputID)
        {
            string key = "294503193ad5ff89e94382e08c7a13b2";
            string queryString = "http://api.openweathermap.org/data/2.5/forecast?q=" + InputID + "&APPID=" + key + "&units=metric";
            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            List<Forecast> forecast = new List<Forecast>();

            int currentIterator = 0;
            for (int i = 0; i < 5; i++)
            {
                Forecast weather = new Forecast
                {
                    Date = UnixTimeToString((long)results["list"][currentIterator]["dt"]),
                    minTemperature = (string)results["list"][currentIterator]["main"]["temp_min"] + "°C",
                    maxTemperature = (string)results["list"][currentIterator]["main"]["temp_max"],
                    Description = "_" + (string)results["list"][currentIterator]["weather"][0]["icon"]
                };
                weather.Date = UnixTimeToString((long)results["list"][currentIterator]["dt"]);

                currentIterator += 8;
                forecast.Add(weather);
            }
            return forecast;
        }
        public static string UnixTimeToString(long dt)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(dt).ToLocalTime();

            return dateTime.ToString("dd/MM/yyyy");
        }
    }
    
}
