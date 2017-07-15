using BSAWeatherApp.DataService;
using BSAWeatherApp.Models;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAWeatherApp.Tests.ServicesTests
{
    [TestFixture]
    public class HistoryServiceTests
    {
        [Test]
        public void History_Take_All_History_Data()
        {
            //Arrange
            var historyFile1 = new CityHistory { Id = 1, CityName = "Lublin", DateTimeOfSearch = DateTime.Now };
            var historyFile2 = new CityHistory { Id = 2, CityName = "Kiev", DateTimeOfSearch = DateTime.Now };
            var historyFile3 = new CityHistory { Id = 3, CityName = "Uman", DateTimeOfSearch = DateTime.Now };
            int count = 3;
            var historyRepository = A.Fake<IRepository<CityHistory>>();
            A.CallTo(() => historyRepository.GetAll()).Returns(new[] { historyFile1, historyFile2, historyFile3 }.AsEnumerable());

            //Act
            var actualCount = historyRepository.GetAll().Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(count));
        }
    }
}
