using System.Collections.Generic;
using Task_02.Entities;
using Task_02.Printers.Certain;

namespace Task_02.Statistics.Certain
{
    internal class HeroUsagesStatisticProvider
    {
        private readonly List<HeroScoreInfo> _heroScoreInfos;
        private readonly HeroUsagesStatisticCalculator _calculator = new HeroUsagesStatisticCalculator();
        private readonly HeroUsagesStatisticPrinter _printer = new HeroUsagesStatisticPrinter();

        public HeroUsagesStatisticProvider(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            _heroScoreInfos = new List<HeroScoreInfo>(heroScoreInfos);
        }

        public void ShowMostSuccessfulHeros()
        {
            _printer.PrintSuccessful(_calculator.FindMostSuccessfulHeroes(_heroScoreInfos));
        }

        public void ShowMostUnsuccessfulHeros()
        {
            _printer.PrintUnsuccessful(_calculator.FindMostUnsuccessfulHeroes(_heroScoreInfos));
        }

        public void ShowMostFavoriteHeros()
        {
            _printer.PrintFavorite(_calculator.FindMostFavoriteHeroes(_heroScoreInfos));
        }

        public void ShowMostUnfavoriteHeros()
        {
            _printer.PrintUnfavorite(_calculator.FindMostUnfavoriteHeroes(_heroScoreInfos));
        }

        public void ShowMostWinStreakHeros()
        {
            _printer.PrintWinStreak(_calculator.FindMostWinStreakHeroes(_heroScoreInfos));
        }
    }
}
