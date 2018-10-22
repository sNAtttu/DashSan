using DashSan.MobileAppService.Models.Steam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Utilities
{
    public static class SteamUrlBuilders
    {
        public static string BuildGetPlayerAchievementsForGameRequestUrl(SteamEnums.Methods methodName, string userid, string appid, string apikey, string steamBaseUrl)
        {
            return $"{steamBaseUrl}/ISteamUserStats/{methodName.ToString()}/v0001/?appid={appid}&key={apikey}&steamid={userid}";
        }

        public static string BuildGetPlayerSummariesRequestUrl(SteamEnums.Methods methodName, string userid, string apikey, string steamBaseUrl)
        {
            return $"{steamBaseUrl}/ISteamUser/{methodName.ToString()}/v0002/?key={apikey}&steamids={userid}";
        }

        public static string BuildGetFriendRequestUrl(SteamEnums.Methods methodName, string userid, string apikey, string steamBaseUrl)
        {
            return $"{steamBaseUrl}/ISteamUser/{methodName.ToString()}/v0001/?key={apikey}&steamid={userid}&relationship=friend";
        }

        public static string BuildPlayerServiceRequestUrl(SteamEnums.Methods methodName, string userid, string apikey, string steamBaseUrl)
        {
            return $"{steamBaseUrl}/IPlayerService/{methodName.ToString()}/v0001/?key={apikey}&steamid={userid}&format=json";
        }
    }
}
