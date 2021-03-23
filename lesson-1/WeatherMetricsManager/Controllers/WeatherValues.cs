using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMetricsManager
{
    public class WeatherValues
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }

        public WeatherValues(DateTime date, int temperatureC)
        {
            this.Date = date;
            this.TemperatureC = temperatureC;
        }

    }
}
