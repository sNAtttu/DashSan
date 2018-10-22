using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    public class RecentlyPlayedGamesResponse
    {
        public int total_count { get; set; }
        public List<Game> games { get; set; }
    }
}
