using Microsoft.Extensions.Configuration;

namespace aspnet_core_dotnet_core.Model
{
    public class User
    {
        public IConfiguration _configuration;

        public User(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Conn()
        {
            var result = _configuration["DatabaseConnectionString"];
            return result;
        }
    }
}
