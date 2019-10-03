using Microsoft.AspNetCore.Components;
using SimpleWeather.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SimpleWeather.Web.Bases
{
    public class IndexBase : ComponentBase
    {
        public string CityName { get; set; }
        public RenderFragment WeatherRender { get; set; }

        public async Task DisplayWeatherAsync()
        {
            WeatherRender = Render.LoadingComponent();

            //OpenWeatherUri contains API key. It's better to use user secrets for that
            //in development environment but there's a client-side API call.
            var cityNamePlus = CityName.Replace(" ", "+");
            var openWeatherUri = new Uri(
                "https://api.openweathermap.org/data/2.5/weather?q=" + cityNamePlus +
                "&APPID=d5bb735f9e1ce1a846ab736fc9d95dc6");

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = openWeatherUri
            };

            var httpClient = new HttpClient();

            var response = await httpClient.SendAsync(requestMessage);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var weatherJson = JObject.Parse(await response.Content.ReadAsStringAsync());

                    var weather = new Weather
                    {
                        Description = (string)weatherJson["weather"][0]["description"],
                        Temperature = (decimal)weatherJson["main"]["temp"] - 273.15m,
                        Pressure = (decimal)weatherJson["main"]["pressure"],
                        Humidity = (decimal)weatherJson["main"]["humidity"],
                        WindSpeed = (decimal)weatherJson["wind"]["speed"]
                    };
                    WeatherRender = Render.WeatherComponent(weather);
                    break;
                case HttpStatusCode.NotFound:
                    WeatherRender = Render.ErrorComponent("City is not found");
                    break;
                default:
                    WeatherRender = Render.ErrorComponent();
                    break;
            }
        }
    }
}
