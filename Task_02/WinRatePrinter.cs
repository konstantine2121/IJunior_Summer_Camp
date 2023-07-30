using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_02
{
    internal abstract class WinRatePrinter : IPrinter
    {
        private string _winRateFormat = " {0} (винрейт {1:0.00})";

        public abstract void Print(IEnumerable<HeroScoreInfo> heroes);

        protected string GetWinRateString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(_winRateFormat, heroScoreInfo.HeroName, heroScoreInfo.GetWinRate());
        }
    }

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

    internal abstract class NumberOfMatchesPrinter : IPrinter
    {
        private string _matchesFormat = " {0} ({1} матчей)";

        public abstract void Print(IEnumerable<HeroScoreInfo> heroes);

        protected string GetMatchesString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(_matchesFormat, heroScoreInfo.HeroName, heroScoreInfo.GetNumberOfPlayedMatches());
        }
    }

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