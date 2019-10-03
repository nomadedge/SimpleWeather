using Microsoft.AspNetCore.Components;
using SimpleWeather.Web.Models;
using SimpleWeather.Web.Shared;

namespace SimpleWeather.Web.Bases
{
    public static class Render
    {
        public static RenderFragment WeatherComponent(Weather weather) => builder =>
        {
            builder.OpenComponent(0, typeof(WeatherComponent));
            builder.AddAttribute(1, "Weather", weather);
            builder.CloseComponent();
        };

        public static RenderFragment ErrorComponent(string errorMessage = "Unknown error") => builder =>
        {
            builder.OpenComponent(0, typeof(ErrorComponent));
            builder.AddAttribute(1, "ErrorMessage", errorMessage);
            builder.CloseComponent();
        };

        public static RenderFragment LoadingComponent() => builder =>
        {
            builder.OpenComponent(0, typeof(LoadingComponent));
            builder.CloseComponent();
        };
    }
}
