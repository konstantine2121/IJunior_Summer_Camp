﻿using System;
using System.Collections.Generic;
using System.Linq;
using Task_02.Entities;

namespace Task_02.Printers.Abstract.NumberOfMatches
{
    internal class UnfavoritePrinter : NumberOfMatchesPrinter
    {
        public string _unfavoriteMessage = "Самый нелюбимый герой: ";

        public override void Print(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var streaks = heroScoreInfos.Select(info => GetMatchesString(info));
            var line = _unfavoriteMessage + string.Join(", ", streaks);
            Console.WriteLine(line);
        }
    }
}