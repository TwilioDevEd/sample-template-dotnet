using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioSampleApp.Domain.Twilio
{
    public interface IMessageSender
    {
        Task<string> SendSms(string to, string body);
    }

    public class MessageSender : IMessageSender
    {
        private readonly TwilioConfiguration _configuration;

        public MessageSender(TwilioConfiguration configuration)
        {
            _configuration = configuration;
            TwilioClient.Init(_configuration.AccountSid, _configuration.AuthToken);
        }

        public async Task<string> SendSms(string to, string body)
        {
            var messageResource = await MessageResource.CreateAsync(
                to: new PhoneNumber(to),
                from: new PhoneNumber(_configuration.PhoneNumber),
                body: body);
            return messageResource.Sid;
        }
    }
}