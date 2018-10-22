﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashSan.MobileAppService.Models.Steam
{
    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_2weeks { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
    }
}
