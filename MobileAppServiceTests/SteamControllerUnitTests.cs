using System;
using Xunit;
using DashSan.MobileAppService.Controllers;
using DashSan.MobileAppService.Models;
using Microsoft.Extensions.Options;

namespace MobileAppServiceTests
{
    public class MockedApiKeys : IOptions<ApiKeys>
    {
        public ApiKeys Value => new ApiKeys { SteamApiKey = "Test" };
    }

    public class SteamControllerUnitTests
    {
        [Fact]
        public void TestBuildGetPlayerSummariesRequestUrl()
        {
            SteamController steamController = new SteamController(new MockedApiKeys());
            string expectedUrl = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=Test&steamids=123";
            string url = steamController.BuildGetPlayerSummariesRequestUrl(DashSan.MobileAppService.Models.Steam.Enums.SteamEnums.Methods.GetPlayerSummaries, "123");
            Assert.Equal(expectedUrl, url);
        }
    }
}
