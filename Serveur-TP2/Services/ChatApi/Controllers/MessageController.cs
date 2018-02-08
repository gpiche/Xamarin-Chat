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
       private const string _apiKey = "AIzaSyCf5hipiBSLY_VpZin_QlIU2bjoAOsaSkA";

        [HttpGet]
        public void GetMessage()
        {
            var jGcmData = new JObject();
            var jdata = new JObject();

            jdata.Add("message", "test");
            jGcmData.Add("to", "/topics/global");
            jGcmData.Add("data", jdata);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + _apiKey);

                    Task.WaitAll(client.PostAsync(url,
                            new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
                        .ContinueWith(response =>
                        {
                            Console.WriteLine(response);
                            Console.WriteLine("Message sent: check the client device notification tray.");
                        }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to send GCM message:");
                Console.Error.WriteLine(e.StackTrace);
            }
        }

     
    }
}
