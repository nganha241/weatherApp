using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using weather_app.Models;

namespace weather_app.Services
{
    public static class ApiService
    {
        public static async Task<Root> GetWeather(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=7db7f7f1454b662870a48eb474a823f9", latitude, longitude));
            return JsonConvert.DeserializeObject<Root>(response);
        }
        public static async Task<Root> GetWeatherByCity(string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid=7db7f7f1454b662870a48eb474a823f9", city));
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
