using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using SimpleWeather.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleWeather.Web.Bases
{
    public class IndexBase : ComponentBase
    {
        public string CityName { get; set; }
        public RenderFragment WeatherRender { get; set; }

        public async Task PressEnter(ChangeEventArgs eventArgs)
        {
            CityName = eventArgs.Value as string;

            await DisplayWeatherAsync();
        }

        public async Task DisplayWeatherAsync()
        {
            WeatherRender = Render.LoadingComponent();

            if (string.IsNullOrWhiteSpace(CityName))
            {
                WeatherRender = Render.ErrorComponent("Empty search. Please type smth");
                return;
            }
            
            var cityNamePlus = CityName.Trim().Replace(" ", "+");
            //OpenWeatherUri contains API key. It's better to use user secrets for that
            //in development environment but there's a client-side API call.
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
                        Description = char.ToUpper(((string)weatherJson["weather"][0]["description"])[0]) +
                            ((string)weatherJson["weather"][0]["description"]).Substring(1),
                        Temperature = (int)Math.Round((decimal)weatherJson["main"]["temp"] - 273.15m),
                        Pressure = (decimal)weatherJson["main"]["pressure"],
                        Humidity = (decimal)weatherJson["main"]["humidity"],
                        WindSpeed = (decimal)weatherJson["wind"]["speed"],
                        IconUrl = "http://openweathermap.org/img/w/" +
                            (string)weatherJson["weather"][0]["icon"] + ".png"
                    };
                    WeatherRender = Render.WeatherComponent(weather);
                    break;
                case HttpStatusCode.NotFound:
                    WeatherRender = Render.ErrorComponent("City not found");
                    break;
                default:
                    WeatherRender = Render.ErrorComponent();
                    break;
            }
        }
    }
}
