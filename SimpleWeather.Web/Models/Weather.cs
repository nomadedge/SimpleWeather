namespace SimpleWeather.Web.Models
{
    public class Weather
    {
        public string Description { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
    }
}
