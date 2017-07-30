using BSAWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BSAWeatherApp.API
{
    public class ForecastController : ApiController
    {
        IForecastProvider forecastProvider;
        IUrlGenerator urlGenerator;
        public ForecastController(IForecastProvider forecastProvider, IUrlGenerator urlGenerator)
        {
            this.forecastProvider = forecastProvider;
            this.urlGenerator = urlGenerator;
        }

        // GET api/forecast/Uman/7

        [Route("api/forecast/{cityName}/{daysCount}")]
        public IHttpActionResult Get(string cityName, string daysCount)
        {
            if (String.IsNullOrEmpty(cityName))
                return BadRequest();
            if (string.IsNullOrEmpty(daysCount))
                return BadRequest();
            try
            {
                var url = urlGenerator.GenerateForecastUrl("", cityName, daysCount);
                var model = forecastProvider.GetWeatherForecastObject(url);
                return Ok(model);
            }
            catch (AggregateException e)
            {
                return NotFound();
            }
        }

        [Route("api/forecast/{cityName}")]
        public IHttpActionResult Get(string cityName)
        {
            if (String.IsNullOrEmpty(cityName))
                return BadRequest();
            try
            {
                var url = urlGenerator.GenerateWeatherUrl(cityName);
                var model = forecastProvider.GetWeatherNowObject(url);
                return Ok(model);
            }
            catch (AggregateException e)
            {
                return NotFound();
            }
        }

    }
}