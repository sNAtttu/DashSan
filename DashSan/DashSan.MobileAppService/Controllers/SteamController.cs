using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DashSan.MobileAppService.Models;
using DashSan.MobileAppService.Models.Steam;
using DashSan.MobileAppService.Models.Steam.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DashSan.MobileAppService.Controllers
{
    [Route("api/steam")]
    public class SteamController : Controller
    {
        private readonly ApiKeys _apiKeys;
        private readonly string steamBaseUrl = "http://api.steampowered.com";


        public SteamController(IOptions<ApiKeys> apiKeys)
        {
            _apiKeys = apiKeys.Value;
        }

        [HttpGet("GetPlayerSummaries/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPlayerSummaries(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = BuildGetPlayerSummariesRequestUrl(SteamEnums.Methods.GetPlayerSummaries, userid);
            GetPlayerSummariesResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerSummariesResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetFriendList/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetFriendList(string userid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = BuildGetFriendRequestUrl(SteamEnums.Methods.GetFriendList, userid);
            GetFriendListResponse jsonResponse =
              JsonConvert.DeserializeObject<GetFriendListResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetPlayerAchievements/{userid}/{appid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPlayerAchievements(string userid, string appid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = BuildGetPlayerAchievementsForGameRequestUrl(SteamEnums.Methods.GetPlayerAchievements, userid, appid);
            GetPlayerAchievementsResponse jsonResponse =
              JsonConvert.DeserializeObject<GetPlayerAchievementsResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        [HttpGet("GetRecentlyPlayedGames/{userid}/")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetRecentlyPlayedGames(string userid, string appid)
        {
            WebClient webClient = new WebClient();
            string reqUrl = BuildRecentlyPlayedGamesRequestUrl(SteamEnums.Methods.GetRecentlyPlayedGames, userid);
            RecentlyPlayedGamesResponse jsonResponse =
              JsonConvert.DeserializeObject<RecentlyPlayedGamesResponse>(webClient.DownloadString(reqUrl));
            return Ok(jsonResponse);
        }

        #region String builder methods

        public string BuildGetPlayerAchievementsForGameRequestUrl(SteamEnums.Methods methodName, string userid, string appid)
        {
            return $"{steamBaseUrl}/ISteamUserStats/{methodName.ToString()}/v0001/?appid={appid}&key={_apiKeys.SteamApiKey}&steamid={userid}";
        }

        public string BuildGetPlayerSummariesRequestUrl(SteamEnums.Methods methodName, string userid)
        {
            return $"{steamBaseUrl}/ISteamUser/{methodName.ToString()}/v0002/?key={_apiKeys.SteamApiKey}&steamids={userid}";
        }

        public string BuildGetFriendRequestUrl(SteamEnums.Methods methodName, string userid)
        {
            return $"{steamBaseUrl}/ISteamUser/{methodName.ToString()}/v0001/?key={_apiKeys.SteamApiKey}&steamid={userid}&relationship=friend";
        }

        public string BuildRecentlyPlayedGamesRequestUrl(SteamEnums.Methods methodName, string userid)
        {
            return $"{steamBaseUrl}IPlayerService/{methodName.ToString()}/v0001/?key={_apiKeys.SteamApiKey}&steamid={userid}&format=json";
        }

        #endregion

    }
}