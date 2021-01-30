using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class IpController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public dynamic Get(string format)
        {
            try
            {
                if (format == "json")
                {
                    return Json(new { ip = this.HttpContext.Connection.RemoteIpAddress.ToString() });
                }
                else
                {
                    return this.HttpContext.Connection.RemoteIpAddress.ToString();
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
