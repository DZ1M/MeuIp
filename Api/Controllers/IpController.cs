﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("[controller]")]
    [Route("/")]
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

                return this.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
