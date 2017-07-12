using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;
using BSAWeatherApp.Services;
using System;
using System.Collections;
using System.Web.Mvc;

namespace BSAWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        IUrlGenerator urlGenerator;
        IForecastProvider forecastProvider;
        IRepository<CityModel> citiesDb;
        IRepository<CityHistory> citiesHistoryDb;

        public WeatherController(IForecastProvider forecastProvider, IUrlGenerator urlGenerator,
            IRepository<CityModel> citiesDb, IRepository<CityHistory> citiesHistoryDb)
        {
            this.forecastProvider = forecastProvider;
            this.urlGenerator = urlGenerator;
            this.citiesDb = citiesDb;
            this.citiesHistoryDb = citiesHistoryDb;
        }

        // GET: Weather/Settings
        public ActionResult Home()
        {
            var cities = citiesDb.GetAll();
            return View(cities);
        }

        // POST : Weather/WeatherNow
        [HttpPost]
        public ActionResult WeatherNow(string weatherCity)
        {
            try
            {
                var url = urlGenerator.GenerateWeatherUrl(weatherCity);
                var model = forecastProvider.GetWeatherNowObject(url);
                citiesHistoryDb.Create(new CityHistory
                {
                    CityName = weatherCity,
                    DateTimeOfSearch = DateTime.Now
                });
                citiesHistoryDb.Save();
                return PartialView(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

        // POST: Weather/Forecast
        [HttpPost]
        public ActionResult Forecast(string defaultCity, string customCity, string daysCount)
        {
            try
            {
                var url = urlGenerator.GenerateForecastUrl(defaultCity, customCity, daysCount);
                var model = forecastProvider.GetWeatherForecastObject(url);
                citiesHistoryDb.Create(new CityHistory {
                    CityName = model.City.Name,
                    DateTimeOfSearch = DateTime.Now
                });
                citiesHistoryDb.Save();
                return PartialView(model);
            }
            catch (AggregateException e)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

        //GET: Weather/Settings
        public ActionResult Settings()
        {
            var data = citiesDb.GetAll();
            return View(data);
        }

        //POST: Weather/AddCity
        [HttpPost]
        public ActionResult AddCity(CityModel city)
        {
            if (city != null)
            {
                citiesDb.Create(city);
                citiesDb.Save();
                return Json(new { Success = true, City = city });
            }
            return Json(new { Success = false });
        }

        //POST: Weather/DeleteCity
        [HttpPost]
        public ActionResult DeleteCity(int id)
        {
            if (id != 0)
            {
                citiesDb.Delete(id);
                citiesDb.Save();
                return Json(new { Message = "Deleted!" });
            }
            return Json(new { Message = "Error!" });

        }

        //POST: Weather/UpdateCity
        [HttpPost]
        public ActionResult UpdateCity(CityModel city)
        {
            if (city != null)
            {
                citiesDb.Update(city);
                citiesDb.Save();
                return Json(new { Message = "Deleted!" });
            }
            return Json(new { Message = "Error!" });

        }
    }
}