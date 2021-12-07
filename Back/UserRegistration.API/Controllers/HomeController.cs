using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.API.Controllers
{
    [ApiController]    
    public class HomeController : ControllerBase    
    {
        [HttpGet("")]
        public string Version() => "Api version 1.0.1";
    }
}
