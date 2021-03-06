﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_Decimals_Library_Game
{
    class Level1Categories
    {
        public Dictionary<string, string> level1Numbers { get; }
        public Level1Categories()
        {
            level1Numbers = new Dictionary<string, string>();

            level1Numbers.Add("000", "Computers, General & Info");
            level1Numbers.Add("100", "Philosophy & Psychology");
            level1Numbers.Add("200", "Religion");
            level1Numbers.Add("300", "Sociology & Anthropology");
            level1Numbers.Add("400", "Language");
            level1Numbers.Add("500", "Natural sciences & mathematics");
            level1Numbers.Add("600", "Technology");
            level1Numbers.Add("700", "Arts, Sports & Entertainment");
            level1Numbers.Add("800", "Literature");
            level1Numbers.Add("900", "History & geography");
        }
    }
}
