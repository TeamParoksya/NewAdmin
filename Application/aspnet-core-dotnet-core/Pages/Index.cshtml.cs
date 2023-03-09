using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using aspnet_core_dotnet_core.Model;

namespace aspnet_core_dotnet_core.Pages
{
   
    public class IndexModel : PageModel
    {

        public readonly IConfiguration _configuration;
        public IndexModel() { }


        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {

        }
        public string DoTest()
        {
            return "Index";
        }

        public string Conn()
        {
            var result = _configuration["DatabaseConnectionString"];
            return result;
        }

        public string Conn2()
        {
            var result = _configuration["SecretKey"];
            return result;
        }

    }
}