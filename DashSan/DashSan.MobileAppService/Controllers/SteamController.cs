using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DashSan.MobileAppService.Models;
using DashSan.MobileAppService.Models.Steam;
using DashSan.MobileAppService.Models.Steam.Enums;
using DashSan.MobileAppService.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DashSan.MobileAppService.Controllers
{
    [Route("api/steam")]
    public class SteamController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApiKeys _apiKeys;
        private readonly string steamBaseUrl = "http://api.steampowered.com";


        public SteamController(IOptions<ApiKeys> apiKeys, ILogger<SteamController> logger)
        {
            _apiKeys = apiKeys.Value;
            _logger = logger;
        }

        [HttpGet("GetPlayerSummaries/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPlayerSummaries(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = SteamUrlBuilders.BuildGetPlayerSummariesRequestUrl(SteamEnums.Methods.GetPlayerSummaries, userid, _apiKeys.SteamApiKey, steamBaseUrl);
            GetPlayerSummariesResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerSummariesResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetFriendList/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetFriendList(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = SteamUrlBuilders.BuildGetFriendRequestUrl(SteamEnums.Methods.GetFriendList, userid, _apiKeys.SteamApiKey, steamBaseUrl);
            GetFriendListResponse jsonResponse =
              JsonConvert.DeserializeObject<GetFriendListResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetPlayerAchievements/{userid}/{appid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPlayerAchievements(string userid, string appid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = SteamUrlBuilders.BuildGetPlayerAchievementsForGameRequestUrl(SteamEnums.Methods.GetPlayerAchievements, userid, appid, _apiKeys.SteamApiKey, steamBaseUrl);
            GetPlayerAchievementsResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerAchievementsResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetRecentlyPlayedGames/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetRecentlyPlayedGames(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = SteamUrlBuilders.BuildPlayerServiceRequestUrl(SteamEnums.Methods.GetRecentlyPlayedGames, userid, _apiKeys.SteamApiKey, steamBaseUrl);
            _logger.LogInformation($"Sending request to {reqUrl}");
            string jsonResponse = webClient.DownloadString(reqUrl);
            _logger.LogInformation($"Response got: {jsonResponse}");
            RecentlyPlayedGamesResponse recentlyPlayedGames = JsonConvert.DeserializeObject<RecentlyPlayedGamesResponse>(jsonResponse);
            return Ok(recentlyPlayedGames);
        }

        [HttpGet("GetOwnedGames/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetOwnedGames(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = SteamUrlBuilders.BuildPlayerServiceRequestUrl(SteamEnums.Methods.GetOwnedGames, userid, _apiKeys.SteamApiKey, steamBaseUrl);
            _logger.LogInformation($"Sending request to {reqUrl}");
            string jsonResponse = webClient.DownloadString(reqUrl);
            _logger.LogInformation($"Response got: {jsonResponse}");
            GetOwnedGameResponse ownedGames = JsonConvert.DeserializeObject<GetOwnedGameResponse>(jsonResponse);
            return Ok(ownedGames);
        }

    }
}