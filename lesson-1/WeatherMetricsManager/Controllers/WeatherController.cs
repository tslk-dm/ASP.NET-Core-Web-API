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
        private readonly WeatherList _values;

        public WeatherController(WeatherList values)
        {
            this._values = values;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime dateTime, [FromQuery] int temperatureC)
        {
            var weatherValues = new WeatherValues(dateTime, temperatureC);
            _values.weatherValuesList.Add(weatherValues);
            return Ok();
        }


        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_values.weatherValuesList);
        }

        [HttpGet("readInterval")]
        public IActionResult ReadInterval([FromQuery] DateTime startOfTime, [FromQuery] DateTime endOfTime)
        {
            List<WeatherValues> readList = new List<WeatherValues>();
            foreach (WeatherValues item in _values.weatherValuesList)
            {
                if (startOfTime <= item.Date &&
                    item.Date <= endOfTime)
                {
                    readList.Add(item);
                }
            }

            return Ok(readList);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime dateTime, [FromQuery] int temperatureC)
        {
            foreach (var item in _values.weatherValuesList)
            {
                if (item.Date == dateTime)
                {
                    item.TemperatureC = temperatureC;
                } 
            }

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime startOfTime, [FromQuery] DateTime endOfTime)
        {
            for (int i = _values.weatherValuesList.Count - 1; i >= 0; i--)
            {
                if (startOfTime <= _values.weatherValuesList[i].Date &&
                    _values.weatherValuesList[i].Date <= endOfTime)
                {
                    _values.weatherValuesList.RemoveAt(i);
                }

            }

            return Ok();
        }
 
    }
}
