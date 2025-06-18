using example_web_app.Classes;
using example_web_app.Controllers;
using example_web_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics;

namespace example_web_app_tests
{
    [TestClass]
    public sealed class HomeControllerTests
    {
        private Mock<ILogger<HomeController>>? _mockLogger;
        private HomeController? _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_mockLogger.Object);
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller!.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Privacy_ReturnsViewResult()
        {
            // Act
            var result = _controller!.Privacy();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ContactUs_ReturnsViewResult()
        {
            // Act
            var result = _controller!.ContactUs();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Error_ReturnsViewResultWithErrorViewModel()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            httpContext.TraceIdentifier = "test-trace-id";
            _controller!.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));
            var model = result.Model as ErrorViewModel;
            Assert.AreEqual("test-trace-id", model!.RequestId);
        }

        [TestMethod]
        public void Error_WithActivityCurrent_ReturnsViewResultWithActivityId()
        {
            // Arrange
            using var activity = new Activity("test-activity");
            activity.Start();
            var httpContext = new DefaultHttpContext();
            _controller!.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));
            var model = result.Model as ErrorViewModel;
            Assert.AreEqual(activity.Id, model!.RequestId);
            
            activity.Stop();
        }
    }

    [TestClass]
    public sealed class ErrorViewModelTests
    {
        [TestMethod]
        public void RequestId_WhenNull_ShowRequestIdReturnsFalse()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = null };

            // Act & Assert
            Assert.IsFalse(model.ShowRequestId);
        }

        [TestMethod]
        public void RequestId_WhenEmpty_ShowRequestIdReturnsFalse()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = string.Empty };

            // Act & Assert
            Assert.IsFalse(model.ShowRequestId);
        }

        [TestMethod]
        public void RequestId_WhenWhitespace_ShowRequestIdReturnsTrue()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = "   " };

            // Act & Assert
            Assert.IsTrue(model.ShowRequestId);
        }

        [TestMethod]
        public void RequestId_WhenHasValue_ShowRequestIdReturnsTrue()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = "test-request-id" };

            // Act & Assert
            Assert.IsTrue(model.ShowRequestId);
        }

        [TestMethod]
        public void RequestId_Property_CanBeSetAndRetrieved()
        {
            // Arrange
            var model = new ErrorViewModel();
            var expectedId = "test-id-123";

            // Act
            model.RequestId = expectedId;

            // Assert
            Assert.AreEqual(expectedId, model.RequestId);
        }
    }

    [TestClass]
    public sealed class HelloWorldTests
    {
        [TestMethod]
        public void GetMessage_ReturnsExpectedMessage()
        {
            // Arrange
            var helloWorld = new HelloWorld();

            // Act
            var result = helloWorld.GetMessage();

            // Assert
            Assert.AreEqual("Hello, World!", result);
        }

        [TestMethod]
        public void HelloWorld_ImplementsIHelloWorldInterface()
        {
            // Arrange & Act
            var helloWorld = new HelloWorld();

            // Assert
            Assert.IsInstanceOfType(helloWorld, typeof(IHelloWorld));
        }

        [TestMethod]
        public void GetMessage_WithInterfaceReference_ReturnsExpectedMessage()
        {
            // Arrange
            IHelloWorld helloWorld = new HelloWorld();

            // Act
            var result = helloWorld.GetMessage();

            // Assert
            Assert.AreEqual("Hello, World!", result);
        }
    }
}
