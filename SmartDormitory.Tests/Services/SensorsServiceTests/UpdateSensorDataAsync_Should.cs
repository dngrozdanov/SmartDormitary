﻿using System.Threading.Tasks;
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
    public class UpdateSensorDataAsync_Should
    {
        [TestMethod]
        public async Task Update_SensorData_Value()
        {
            var contextOptions = new DbContextOptionsBuilder<SmartDormitaryContext>()
                .UseInMemoryDatabase("Update_SensorData_Value")
                .Options;

            var sensor = TestHelpers.TestPublicSensor();
            var val = "12";

            // Act
            using (var actContext = new SmartDormitaryContext(contextOptions))
            {
                await actContext.Sensors.AddAsync(sensor);
                await actContext.SaveChangesAsync();
            }

            // Assert
            using (var assertContext = new SmartDormitaryContext(contextOptions))
            {
                var hubServiceMock = new Mock<IHubService>();
                hubServiceMock
                    .Setup(s => s.Notify(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                        It.IsAny<string>())).Returns(Task.CompletedTask);

                var service = new SensorsService(assertContext, hubServiceMock.Object);
                var toUpdate = await assertContext.Sensors
                    .Include(s => s.SensorType)
                    .Include(s => s.SensorData).SingleAsync();

                toUpdate.SensorData.Value = val;
                var result = await service.UpdateSensorDataAsync(toUpdate);

                Assert.AreEqual(val, result.Entity.Value);
            }
        }
    }
}