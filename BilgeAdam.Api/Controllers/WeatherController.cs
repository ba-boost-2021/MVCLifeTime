using BilgeAdam.Common.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BilgeAdam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherApiSettings settings;

        public WeatherController(IOptions<Settings> options)
        {
            settings = options.Value.Weather;
        }

        [HttpGet("city/{code}")]
        public IActionResult GetWeatherByCityCode([FromRoute] Guid code)
        {
            if (!Cities.GetCities.ContainsKey(code))
            {
                return BadRequest("invalid code");
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(settings.Url);
                var url = $"v1/current.json?key={settings.Key}&q={Cities.GetCities[code]}&aqi=no";
                var response = client.GetAsync(url).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonSerializer.Deserialize<WeatherResult>(json);
                return Ok(result);
            }
        }
    }

    class Cities
    {
        public static Dictionary<Guid, string> GetCities => new Dictionary<Guid, string>
            {
                { new Guid("D309A3EB-1597-451F-B51F-959FF902BD30"), "Ankara"},
                { new Guid("C6A29E08-8042-41D9-8B98-9D19EDC8075C"), "Istanbul" }
            };
    }


    public class WeatherResult
    {
        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("temp_c")]
        public float Celcius { get; set; }
        public int is_day { get; set; }
        public Condition condition { get; set; }
        public float wind_mph { get; set; }
        public int wind_degree { get; set; }
        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }
        [JsonPropertyName("pressure_mb")]
        public float Pressure { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public float feelslike_c { get; set; }
        public float vis_km { get; set; }
        public float uv { get; set; }
    }

    public class Condition
    {
        [JsonPropertyName("text")]
        public string Status { get; set; }
    }

}
