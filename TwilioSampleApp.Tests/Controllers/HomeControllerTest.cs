using System;
using Microsoft.AspNetCore.Mvc;
using TwilioSampleApp.Controllers;
using Xunit;

namespace TwilioSampleApp.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void TestIndex()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}