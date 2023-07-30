using System.Collections.Generic;
using Task_02.Printers;

namespace Task_02.Statistics
{
    internal class HeroUsagesStatisticMostFavoriteProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostFavoriteProvider(List<HeroScoreInfo> infos) : base (infos, new FavoritePrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostFavoriteHeros(Infos));
        }
    }
}