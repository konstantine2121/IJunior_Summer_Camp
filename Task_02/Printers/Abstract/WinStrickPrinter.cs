using System;
using System.Collections.Generic;
using System.Linq;
using Task_02.Statistics;

namespace Task_02.Printers
{
    internal class WinStrickPrinter : IPrinter
    {
        public string _winStreakFormat => " {0} (винстрик {1})";
        private string _winStreakMessage = "Герой с самым большим винстриком: ";

        public void Print(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var streaks = heroScoreInfos.Select(info => GetWinStreakString(info));
            var line = _winStreakMessage + string.Join(", ", streaks);
            Console.WriteLine(line);
        }

        private string GetWinStreakString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(_winStreakFormat, heroScoreInfo.HeroName, heroScoreInfo.GetWinStreak());
        }
    }
}