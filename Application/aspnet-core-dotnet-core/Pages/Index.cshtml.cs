using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace aspnet_core_dotnet_core.Pages
{
   
    public class IndexModel : PageModel
    {

        public IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Name { get; set; }
        public string Description { get; set; }
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

        //public List<string> Get()
        //{
        //    List<string> result = new List<string>() {
        //        _configuration["DatabaseConnectionString"],
        //            _configuration["RedisCache"]
        //    };
        //    return result;

        //}

    }
}