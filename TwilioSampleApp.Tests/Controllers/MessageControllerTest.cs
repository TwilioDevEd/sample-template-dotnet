using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TwilioSampleApp.Controllers;
using Xunit;
using Moq;
using Twilio.Exceptions;
using TwilioSampleApp.Domain.Twilio;
using TwilioSampleApp.Models;

namespace TwilioSampleApp.Tests.Controllers
{
    public class MessageControllerTest
    {
        [Fact]
        public async Task TestSendSmsOnSuccess()
        {
            // Arrange
            var mockSender = new Mock<IMessageSender>();
            mockSender.Setup(sender => sender.SendSms("1111", "message")).ReturnsAsync("SID");
            var mockLogger = new Mock<ILogger<MessageController>>();
            var controller = new MessageController(mockSender.Object, mockLogger.Object);

            // Act
            var result = await controller.SendAsync(new MessageRequestDataModel {To = "1111", Body = "message"});

            // Assert
            var dataResult = Assert.IsType<MessageResultDataModel>(result);
            Assert.Equal("success", dataResult.Status);
            Assert.Contains("1111", dataResult.Message);
            Assert.Contains("SID", dataResult.Message);
        }

        [Fact]
        public async Task TestSendSmsOnFailure()
        {
            // Arrange
            var mockSender = new Mock<IMessageSender>();
            mockSender.Setup(sender => sender.SendSms("1111", "message")).Throws<TwilioException>();
            var mockLogger = new Mock<ILogger<MessageController>>();
            var controller = new MessageController(mockSender.Object, mockLogger.Object);

            // Act
            var result = await controller.SendAsync(new MessageRequestDataModel {To = "1111", Body = "message"});

            // Assert
            var dataResult = Assert.IsType<MessageResultDataModel>(result);
            Assert.Equal("error", dataResult.Status);
            Assert.StartsWith("Failed to send SMS", dataResult.Message);
        }
        
    }
}