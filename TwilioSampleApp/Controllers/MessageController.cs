using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Twilio.Exceptions;
using TwilioSampleApp.Domain.Twilio;
using TwilioSampleApp.Models;

namespace TwilioSampleApp.Controllers
{
    public class MessageController : ControllerBase
    {
        private readonly IMessageSender _sender;
        private readonly ILogger<MessageController> _logger;

        public MessageController(IMessageSender sender, ILogger<MessageController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        // POST to /send-sms
        [HttpPost]
        [AllowAnonymous]
        public async Task<MessageResultViewModel> Send([FromBody] MessageRequestViewModel data)
        {
            try
            {
                var sid = await _sender.SendSms(data.To, data.Body);
                return new MessageResultViewModel
                {
                    Status = "success",
                    Message = $"SMS sent to {data.To}. Message SID: {sid}"
                };
            }
            catch (TwilioException exception)
            {
                _logger.LogError(exception, "Error sending SMS");
                return new MessageResultViewModel
                {
                    Status = "error",
                    Message = "Failed to send SMS. Check server logs for more details."
                };
            }
        }
    }
}