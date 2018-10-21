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

        [HttpGet("GetPlayerSummaries/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPlayerSummaries(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={_apiKeys.SteamApiKey}&steamids={userid}";
            GetPlayerSummariesResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerSummariesResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetFriendList/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetFriendList(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = $"http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key={_apiKeys.SteamApiKey}&steamid={userid}&relationship=friend";
            GetFriendListResponse jsonResponse =
              JsonConvert.DeserializeObject<GetFriendListResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetPlayerAchievements/{userid}/{appid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPlayerAchievements(string userid, string appid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = $"http://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v0001/?appid={appid}&key={_apiKeys.SteamApiKey}&steamid={userid}";
            GetPlayerAchievementsResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerAchievementsResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

    }
}