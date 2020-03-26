using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Twilio.Exceptions;
using TwilioSampleApp.Domain.Twilio;
using Xunit;

namespace TwilioSampleApp.Integration
{
    public class SendMessageTest : IDisposable
    {
        private readonly IHost _host;
        private readonly IWebDriver _driver;

        public SendMessageTest()
        {
            var mockSender = new Mock<IMessageSender>();
            mockSender.Setup(sender => sender.SendSms("1111", "message")).ReturnsAsync("MS1a2b3c");
            mockSender.Setup(sender => sender.SendSms("0000", "invalid")).Throws<TwilioException>();

            var builder = Host.CreateDefaultBuilder(new string[] { })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseEnvironment("testing")
                        .UseStartup<Startup>()
                        .ConfigureServices(services =>
                        {
                            services.AddSingleton<IMessageSender>(mockSender.Object);
                        });
                });
            _host = builder.Build();
            _host.Start();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            _driver = new ChromeDriver(chromeOptions);
        }

        [Fact]
        public void Get_ReturnsCorrectHtmlContent()
        {
            // Act
            _driver.Navigate()
                .GoToUrl("http://localhost:5000");

            // Assert
            Assert.Equal("Home - TwilioSampleApp", _driver.Title);
            Assert.Contains("Welcome to Home", _driver.PageSource);
            Assert.NotNull(_driver.FindElement(By.Name("to")));
            Assert.NotNull(_driver.FindElement(By.Name("body")));
            Assert.NotNull(_driver.FindElement(By.CssSelector("button[type=\"submit\"]")));
        }

        [Fact]
        public void GetJsResource_ReturnsFile()
        {
            // Act
            _driver.Navigate()
                .GoToUrl("http://localhost:5000/js/send-sms.js");

            // Assert
            Assert.Contains("document.getElementById", _driver.PageSource);
        }

        [Fact]
        public void ClickOnButton_PostToSendsAMessageSucceeds()
        {
            // Arrange
            _driver.Navigate()
                .GoToUrl("http://localhost:5000");
            _driver.FindElement(By.Name("to")).SendKeys("1111");
            _driver.FindElement(By.Name("body")).SendKeys("message");

            // Act
            _driver.FindElement(By.CssSelector("button[type=\"submit\"]")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(2)).Until(
                drv => !drv.FindElement(By.Id("dialog")).GetAttribute("class").Contains("d-none"));

            var dialog = _driver.FindElement(By.Id("dialog"));

            // Assert
            Assert.Contains("alert-success", dialog.GetAttribute("class"));
            Assert.Contains("SMS sent to 1111. Message SID: MS1a2b3c", dialog.Text);
        }

        [Fact]
        public void ClickOnButton_PostToSendsAMessageFails()
        {
            // Arrange
            _driver.Navigate()
                .GoToUrl("http://localhost:5000");
            _driver.FindElement(By.Name("to")).SendKeys("0000");
            _driver.FindElement(By.Name("body")).SendKeys("invalid");

            // Act
            _driver.FindElement(By.CssSelector("button[type=\"submit\"]")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(2)).Until(
                drv => !drv.FindElement(By.Id("dialog")).GetAttribute("class").Contains("d-none"));

            var dialog = _driver.FindElement(By.Id("dialog"));

            // Assert
            Assert.Contains("alert-danger", dialog.GetAttribute("class"));
            Assert.Contains("Failed to send SMS", dialog.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
            _host.StopAsync().GetAwaiter().GetResult();
        }
    }
}