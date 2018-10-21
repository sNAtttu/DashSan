using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    public class PlayerStats
    {
        public string steamID { get; set; }
        public string gameName { get; set; }
        public List<Achievement> achievements { get; set; }
        public bool success { get; set; }
    }
}
