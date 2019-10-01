using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
