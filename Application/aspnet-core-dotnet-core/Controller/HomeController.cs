using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace aspnet_core_dotnet_core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public List<string> Get()
        {
            List<string> result = new List<string>() {
                _configuration["DatabaseConnectionString"],
                    _configuration["RedisCache"]
            };
            return result;

        }
    }
}
