using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    public class GetOwnedGameResponse
    {
        public OwnedGameResponse response { get; set; }
    }

    public class OwnedGameResponse
    {
        public int game_count { get; set; }
        public List<OwnedGame> games { get; set; }
    }

}
