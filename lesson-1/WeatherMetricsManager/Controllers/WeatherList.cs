using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMetricsManager
{
    public class WeatherList 
    {
        public List<WeatherValues> weatherValuesList { get; set; }

        public WeatherList()
        {
            weatherValuesList = new List<WeatherValues>();
        }
    }
}
