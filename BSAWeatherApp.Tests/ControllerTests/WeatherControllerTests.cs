using BSAWeatherApp.Controllers;
using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;
using BSAWeatherApp.Models.ViewModels;
using FakeItEasy;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BSAWeatherApp.Tests.ControllerTests
{
    [TestFixture]
    public class WeatherControllerTests
    {
        [Test]
        public void Weather_Controller_Check_Weather_Controller_For_Correct_Instances_And_Model_Values()
        {
            //Arrange
            var controller = DependencyResolver.Current.GetService<WeatherController>();
            //Act
            var viewResult = controller.Home() as ViewResult;
            //Assert
            Assert.IsInstanceOf<ViewResult>(viewResult);
        }
    }
}
