using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_02
{
    internal class HeroUsagesStatisticPrinter
    {
        private const string SuccessfulMessage = "Самый успешный герой: ";
        private const string UnsuccessfulMessage = "Самый неуспешный герой: ";
        private const string FavouriteMessage = "Самый любимый  герой: ";
        private const string UnfavouriteMessage = "Самый нелюбимый герой: ";
        private const string WinStreakMessage = "Герой с самым большим винстриком: ";

        private const string WinRateFormat = " {0} (винрейт {1:0.00})";
        private const string MatchesFormat = " {0} ({1} матчей)";
        private const string WinStreakFormat = " {0} (винстрик {1})";

        public void PrintSuccessful(IEnumerable<HeroScoreInfo> heroScoreInfos) 
        {
            var rates = heroScoreInfos.Select(info => GetWinRateString(info));
            var line = SuccessfulMessage + string.Join(", ", rates);
            Console.WriteLine(line);
        }


        public void PrintUnsuccessful(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var rates = heroScoreInfos.Select(info => GetWinRateString(info));
            var line = UnsuccessfulMessage + string.Join(", ", rates);
            Console.WriteLine(line);
        }

        public void PrintFavourite(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var matchesPlayed = heroScoreInfos.Select(info => GetMatchesString(info));
            var line = FavouriteMessage + string.Join(", ", matchesPlayed);
            Console.WriteLine(line);
        }

        public void PrintUnfavourite(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var matchesPlayed = heroScoreInfos.Select(info => GetMatchesString(info));
            var line = UnfavouriteMessage + string.Join(", ", matchesPlayed);
            Console.WriteLine(line);
        }

        public void PrintWinStreak(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            var streaks = heroScoreInfos.Select(info => GetWinStreakString(info));
            var line = WinStreakMessage + string.Join(", ", streaks);
            Console.WriteLine(line);
        }

        #region Get Strings

        private string GetWinRateString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(WinRateFormat, heroScoreInfo.HeroName, heroScoreInfo.GetWinRate());
        }

        private string GetMatchesString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(MatchesFormat, heroScoreInfo.HeroName, heroScoreInfo.GetNumberOfPlayedMatches());
        }

        private string GetWinStreakString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(WinStreakFormat, heroScoreInfo.HeroName, heroScoreInfo.GetWinStreak());
        }

        #endregion Get Strings
    }
}
