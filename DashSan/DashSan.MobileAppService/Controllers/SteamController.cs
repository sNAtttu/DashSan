using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DashSan.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DashSan.MobileAppService.Controllers
{
    [Route("api/steam")]
    public class SteamController : Controller
    {
        private readonly ApiKeys _apiKeys;

        public SteamController(IOptions<ApiKeys> apiKeys)
        {
            _apiKeys = apiKeys.Value;
        }

        [HttpGet("{userid}")]
        public IActionResult GetUser(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={_apiKeys.SteamApiKey}&steamids={userid}";
            string jsonResponse = webClient.DownloadString(reqUrl);
            return Ok();
        }

    }
}