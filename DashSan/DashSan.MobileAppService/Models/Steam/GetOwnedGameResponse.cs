using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    public class GetOwnedGameResponse
    {
        public int game_count { get; set; }
        public List<OwnedGame> games { get; set; }
    }
}
