using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DashSan.MobileAppService.Models;
using DashSan.MobileAppService.Models.Steam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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
        [ResponseCache(Duration = 60)]
        public IActionResult GetUser(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={_apiKeys.SteamApiKey}&steamids={userid}";
            GetPlayerSummariesResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerSummariesResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

    }
}