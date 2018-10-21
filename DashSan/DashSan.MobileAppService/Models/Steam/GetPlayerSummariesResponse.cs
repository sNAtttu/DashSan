using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    [JsonObject]
    public class GetPlayerSummariesResponse
    {
        public Players response { get; set; }
    }
}
