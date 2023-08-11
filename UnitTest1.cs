using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ShuttleBusBooking.Controllers;
using ShuttleBusBooking.Data;
using Microsoft.Extensions.Logging;
using ShuttleBusBooking.Models;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace ShuttleBusTest2
{
    public class UnitTest1
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShuttleBusBookingContext _context;

        public UnitTest1()
        {
            _logger = new Mock<ILogger<HomeController>>().Object;
            _context = new Mock<ShuttleBusBookingContext>().Object;
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var controller = new HomeController(null, _logger); // Passing null for context since it's not used
            // Act
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var controller = new HomeController(null, _logger); // Passing null for context since it's not used
            // Act
            var result = controller.Info() as ViewResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Info", result.ViewName);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ShuttleBusBookingContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ShuttleBusBookingContext(options))
            {
                var controller = new HomeController(context, _logger);
                // Act
                var result = controller.Book() as ViewResult;
                // Assert
                Assert.NotNull(result);
                Assert.Equal("Book", result.ViewName);
            }
        }

        [Fact]
        public void TestGetRemainingShuttleServicesWithSameId()
        {
            // Arrange
            var selectedShuttleServiceId = 1; // Replace with the actual value
            var currentId = 1; // Replace with the actual value

            var options = new DbContextOptionsBuilder<ShuttleBusBookingContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ShuttleBusBookingContext(options))
            {
                var httpContextMock = new DefaultHttpContext();
                httpContextMock.Request.Query = new QueryCollection(
                    new Dictionary<string, StringValues>
                    {
                { "currentId", new StringValues(currentId.ToString()) },
                { "selectedShuttleServiceId", new StringValues(selectedShuttleServiceId.ToString()) }
                    });
                var controllerContext = new ControllerContext
                {
                    HttpContext = httpContextMock
                };

                var controller = new HomeController(context, _logger)
                {
                    ControllerContext = controllerContext
                };
                var result = controller.GetRemainingShuttleServices(currentId, selectedShuttleServiceId) as OkObjectResult;
                var remainingShuttleServices = result.Value as List<ShuttleServiceMap>;

                // Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                Assert.NotNull(remainingShuttleServices);
                // Add more assertions as needed
            }
        }

        [Fact]
        public void TestGetRemainingShuttleServicesWithDifferentId()
        {
            // Arrange
            var selectedShuttleServiceId = 1; // Replace with the actual value
            var currentId = 2; // Replace with the actual value

            var options = new DbContextOptionsBuilder<ShuttleBusBookingContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ShuttleBusBookingContext(options))
            {
                var httpContextMock = new DefaultHttpContext();
                httpContextMock.Request.Query = new QueryCollection(
                    new Dictionary<string, StringValues>
                    {
                { "currentId", new StringValues(currentId.ToString()) },
                { "selectedShuttleServiceId", new StringValues(selectedShuttleServiceId.ToString()) }
                    });
                var controllerContext = new ControllerContext
                {
                    HttpContext = httpContextMock
                };

                var controller = new HomeController(context, _logger)
                {
                    ControllerContext = controllerContext
                };
                var result = controller.GetRemainingShuttleServices(currentId, selectedShuttleServiceId) as OkObjectResult;
                var remainingShuttleServices = result.Value as List<ShuttleServiceMap>;

                // Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                Assert.NotNull(remainingShuttleServices);
                // Add more assertions as needed
            }
        }

        [Fact]
        public void TestGetRemainingShuttleServicesWithInvalidId()
        {
            // Arrange
            var selectedShuttleServiceId = 1; // Replace with the actual value
            var currentId = 100; // Replace with the actual value

            var options = new DbContextOptionsBuilder<ShuttleBusBookingContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ShuttleBusBookingContext(options))
            {
                var httpContextMock = new DefaultHttpContext();
                httpContextMock.Request.Query = new QueryCollection(
                    new Dictionary<string, StringValues>
                    {
                { "currentId", new StringValues(currentId.ToString()) },
                { "selectedShuttleServiceId", new StringValues(selectedShuttleServiceId.ToString()) }
                    });
                var controllerContext = new ControllerContext
                {
                    HttpContext = httpContextMock
                };

                var controller = new HomeController(context, _logger)
                {
                    ControllerContext = controllerContext
                };
                var result = controller.GetRemainingShuttleServices(currentId, selectedShuttleServiceId) as OkObjectResult;
                var remainingShuttleServices = result.Value as List<ShuttleServiceMap>;

                // Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                Assert.NotNull(remainingShuttleServices);
                // Add more assertions as needed
            }
        }





    }
}
