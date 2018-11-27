﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartDormitary.Data.Context;
using SmartDormitary.Services;
using SmartDormitory.Tests.HelpersMethods;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDormitory.Tests.Services.SensorsServiceTests
{
    [TestClass]
    public class GetAllSensorsAsync_Should
    {
        [TestMethod]
        public async Task Return_EmptySensorList()
        {
            var contextOptions = new DbContextOptionsBuilder<SmartDormitaryContext>()
                .UseInMemoryDatabase(databaseName: "Return_EmptySensorList_Async")
                .Options;

            // Assert
            using (var assertContext = new SmartDormitaryContext(contextOptions))
            {
                var service = new SensorsService(assertContext);
                var result = await service.GetAllSensorsAsync();

                Assert.AreEqual(0, result.Count);
            }
        }


        [TestMethod]
        public async Task Return_AllSensors()
        {
            var contextOptions = new DbContextOptionsBuilder<SmartDormitaryContext>()
                .UseInMemoryDatabase(databaseName: "Return_AllSensors_Async")
                .Options;

            var sensor = TestHelpers.TestPublicSensor();

            // Act
            using (var actContext = new SmartDormitaryContext(contextOptions))
            {
                actContext.Sensors.Add(sensor);
                actContext.SaveChanges();
            }

            // Assert
            using (var assertContext = new SmartDormitaryContext(contextOptions))
            {
                var service = new SensorsService(assertContext);
                var result = await service.GetAllSensorsAsync();

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("test", result.First().Name);
            }
        }
    }
}