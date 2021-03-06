﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartDormitary.Data.Context;
using SmartDormitary.Services;
using SmartDormitary.Services.Hubs.Service;
using SmartDormitory.Tests.HelpersMethods;

namespace SmartDormitory.Tests.Services.SensorsServiceTests
{
    [TestClass]
    public class SensorExists_Should
    {
        [TestMethod]
        public async Task Return_SensorExists()
        {
            var contextOptions = new DbContextOptionsBuilder<SmartDormitaryContext>()
                .UseInMemoryDatabase("Return_SensorExists_Async")
                .Options;

            var sensor = TestHelpers.TestPrivateSensor();

            // Act
            using (var actContext = new SmartDormitaryContext(contextOptions))
            {
                actContext.Sensors.Add(sensor);
                actContext.SaveChanges();
            }

            // Assert
            using (var assertContext = new SmartDormitaryContext(contextOptions))
            {
                var hubServiceMock = new Mock<IHubService>();
                var service = new SensorsService(assertContext, hubServiceMock.Object);
                var result = await service.SensorExists(sensor.Id);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task Return_Sensor_DoesntExists()
        {
            var contextOptions = new DbContextOptionsBuilder<SmartDormitaryContext>()
                .UseInMemoryDatabase("Return_Sensor_DoesntExists_Async")
                .Options;

            // Assert
            using (var assertContext = new SmartDormitaryContext(contextOptions))
            {
                var hubServiceMock = new Mock<IHubService>();
                var service = new SensorsService(assertContext, hubServiceMock.Object);
                var result = await service.SensorExists(new Guid());

                Assert.IsFalse(result);
            }
        }
    }
}