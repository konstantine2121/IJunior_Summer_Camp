using System.Collections.Generic;
using Task_02.Entities;
using Task_02.Printers.Abstract.NumberOfMatches;

namespace Task_02.Statistics.Abstract.NumberOfMatches
{
    internal class HeroUsagesStatisticMostFavoriteProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostFavoriteProvider(List<HeroScoreInfo> infos) : base(infos, new FavoritePrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostFavoriteHeroes(Infos));
        }
    }
}