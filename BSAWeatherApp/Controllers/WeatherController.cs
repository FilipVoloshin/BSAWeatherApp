﻿using BSAWeatherApp.Helpers;
using BSAWeatherApp.Models;
using BSAWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather/Settings
        public ActionResult Filter()
        {
            ViewBag.Error = false;
            return View();
        }

        // GET: Weather/Forecast
        public ActionResult Forecast(string defaultCity, string customCity, string period)
        {
            ViewBag.Error = false;
            if (defaultCity == null && customCity == null && period == null)
            {
                ViewBag.Error = true;
                return View("Filter");
            }

            var weatherForecast = new WeatherForecast();
            var jsonWeatherResult = weatherForecast.GetWeatherForecast(defaultCity, customCity, period);
            var dateTimeHelper = new DateTimeHelper();
            var viewModel = new ForecastViewModel();
            viewModel = new ForecastViewModel();
            viewModel.CityName = jsonWeatherResult.city.name;
            viewModel.Country = jsonWeatherResult.city.country;
            var forecasts = new List<Forecasts>();
            foreach (var item in jsonWeatherResult.list.ToList())
            {
                var date = dateTimeHelper.UnixTimeStampToDateTime(item.dt);
                var temperature = new Temperature
                {
                    MorningTemp = item.temp.morn,
                    DayTemp = item.temp.day,
                    EveningTemp = item.temp.eve,
                    MaxTemp = item.temp.max,
                    MinTemp = item.temp.min,
                    NightTemp = item.temp.night
                };
                var weather = new Weathers
                {
                    Main = item.weather.Select(w => w.main).FirstOrDefault(),
                    Description = item.weather.Select(w => w.description).FirstOrDefault()
                };
                var forecastForDay = new Forecasts
                {
                    Date = date,
                    Temperature = temperature,
                    Weather = weather
                };
                forecasts.Add(forecastForDay);
            }
            viewModel.WeatherForecast = forecasts;
            return View(viewModel);
        }

    }
}