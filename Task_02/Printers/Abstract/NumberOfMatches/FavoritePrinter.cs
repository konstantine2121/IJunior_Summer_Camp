﻿using System;
using System.Collections.Generic;
using System.Linq;
using Task_02.Entities;

namespace Task_02.Printers.Abstract.NumberOfMatches
{
    internal class FavoritePrinter : NumberOfMatchesPrinter
    {
        private string _favoriteMessage = "Самый любимый герой: ";

        public override void Print(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var streaks = heroScoreInfos.Select(info => GetMatchesString(info));
            var line = _favoriteMessage + string.Join(", ", streaks);
            Console.WriteLine(line);
        }
    }
}