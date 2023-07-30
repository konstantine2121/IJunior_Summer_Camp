﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_02.Printers
{
    internal class WinRateUnsuccessfulPrinter : WinRatePrinter
    {
        private string _unsuccessfulMessage = "Самый неуспешный герой: ";

        public override void Print(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var streaks = heroScoreInfos.Select(info => GetWinRateString(info));
            var line = _unsuccessfulMessage + string.Join(", ", streaks);
            Console.WriteLine(line);
        }
    }
}