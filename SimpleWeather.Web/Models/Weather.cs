namespace SimpleWeather.Web.Models
{
    public class Weather
    {
        public string Description { get; set; }
        public int Temperature { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
        public string IconUrl { get; set; }
    }
}
