using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    public class Achievement
    {
        public string apiname { get; set; }
        public int achieved { get; set; }
        public int unlocktime { get; set; }
    }
}
