using Microsoft.AspNetCore.Mvc;
using TwilioSampleApp.Models;

namespace TwilioSampleApp.Controllers
{
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public ExampleDataModel Get()
        {
            return new ExampleDataModel { Value = true};
        }
    }
}