using Microsoft.AspNetCore.Mvc;
using TwilioSampleApp.Models;

namespace TwilioSampleApp.Controllers
{
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public ExampleViewModel Get()
        {
            return new ExampleViewModel { Value = true};
        }
    }
}