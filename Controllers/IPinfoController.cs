using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

namespace BanHostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPinfoController : Controller
    {
        [HttpGet]
        public IActionResult E()
        {
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string url = "http://ip-api.com/json/" + ip;

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            return Ok(data);
        }

    }
}
