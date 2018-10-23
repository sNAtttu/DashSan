using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Facebook;
using DashSan.MobileAppService.Models;
using DashSan.MobileAppService.Models.Facebook;
using Microsoft.Extensions.Options;

namespace DashSan.MobileAppService.Controllers
{
    [Route("api/facebook")]
    public class FacebookController : Controller
    {
        private readonly ApiKeys _apiKeys;

        private FacebookClient fbClient;

        public FacebookController(IOptions<ApiKeys> apiKeys)
        {
            _apiKeys = apiKeys.Value;
            CreateFacebookClient();
        }

        private void CreateFacebookClient()
        {
            fbClient = new FacebookClient();
            dynamic result = fbClient.Get("oauth/access_token", new
            {
                client_id = _apiKeys.FacebookAppKey,
                client_secret = _apiKeys.FacebookAppSecret,
                grant_type = "client_credentials"
            });
            fbClient.AccessToken = result.access_token;
        }

        [HttpGet("GetProfileInformation/{userid}")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetProfileInformation(string userid)
        {
            FacebookPersonalModel result = fbClient.Get<FacebookPersonalModel>($"/v3.2/{userid}?fields=name");
            return Ok(result);
        }
    }
}