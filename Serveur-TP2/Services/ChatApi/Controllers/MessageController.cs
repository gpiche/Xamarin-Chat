using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ChatApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
     

        [HttpGet]
        public string GetMessage()
        {
            return "message";
        }

     
    }
}
