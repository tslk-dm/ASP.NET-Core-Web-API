using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherList values;

        public WeatherController(WeatherList values)
        {
            this.values = values;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string dateString, [FromQuery] int temperatureC)
        {
            DateTime dateTime = DateTime.Parse(dateString);
            var weatherValues = new WeatherValues(dateTime, temperatureC);
            values.weatherValuesList.Add(weatherValues);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(values.weatherValuesList);
        }

        [HttpGet("readInterval")]
        public IActionResult ReadInterval([FromQuery] string startOfTimeString, [FromQuery] string endOfTimeString)
        {
            DateTime startOfTime = DateTime.Parse(startOfTimeString);
            DateTime endOfTime = DateTime.Parse(endOfTimeString);

            List<WeatherValues> readList = new List<WeatherValues>();
            for (int i = 0; i < values.weatherValuesList.Count; i++)
            {
                if (startOfTime <= values.weatherValuesList[i].Date && 
                    values.weatherValuesList[i].Date <= endOfTime)
                {
                    readList.Add(values.weatherValuesList[i]);
                }

            }
            return Ok(readList);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string dateString, [FromQuery] int temperatureC)
        {
            DateTime dateTime = DateTime.Parse(dateString);
            for (int i = 0; i < values.weatherValuesList.Count; i++)
            {
                if (values.weatherValuesList[i].Date == dateTime)
                    values.weatherValuesList[i].TemperatureC = temperatureC;
            }

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string startOfTimeString, [FromQuery] string endOfTimeString)
        {
            DateTime startOfTime = DateTime.Parse(startOfTimeString);
            DateTime endOfTime = DateTime.Parse(endOfTimeString);

            for (int i = 0; i < values.weatherValuesList.Count; i++)
            {
                if (startOfTime <= values.weatherValuesList[i].Date &&
                    values.weatherValuesList[i].Date <= endOfTime)
                {
                    values.weatherValuesList.RemoveAt(i);
                    i--;
                }
                
            }

            return Ok();
        }
    }
}
