using System.Collections.Generic;
using Task_02.Printers.Certain;
using Task_02.Statistics;

namespace Task_02
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
            _printer.PrintSuccessful(_calculator.FindMostSuccessfulHeros(_heroScoreInfos));
        }

        public void ShowMostUnsuccessfulHeros()
        {
            _printer.PrintUnsuccessful(_calculator.FindMostUnsuccessfulHeros(_heroScoreInfos));
        }

        public void ShowMostFavoriteHeros()
        {
            _printer.PrintFavorite(_calculator.FindMostFavouriteHeros(_heroScoreInfos));
        }

        public void ShowMostUnfavoriteHeros()
        {
            _printer.PrintUnfavorite(_calculator.FindMostUnfavouriteHeros(_heroScoreInfos));
        }

        public void ShowMostWinStreakHeros()
        {
            _printer.PrintWinStreak(_calculator.FindMostWinStreakHeros(_heroScoreInfos));
        }
    }
}
