using TwilioSampleApp.Controllers;
using TwilioSampleApp.Models;
using Xunit;

namespace TwilioSampleApp.Tests
{
    public class ExampleControllerTest
    {
        [Fact]
        public void TestGet()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            var result = controller.Get();

            // Assert
            var dataResult = Assert.IsType<ExampleDataModel>(result);
            Assert.True(dataResult.Value);
        }
    }
}