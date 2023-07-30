using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_02.Printers.Abstract.WinRate
{
    internal class WinRateSuccessfulPrinter : WinRatePrinter
    {
        private string _successfulMessage = "Самый успешный герой: ";

        public override void Print(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var streaks = heroScoreInfos.Select(info => GetWinRateString(info));
            var line = _successfulMessage + string.Join(", ", streaks);
            Console.WriteLine(line);
        }
    }
}