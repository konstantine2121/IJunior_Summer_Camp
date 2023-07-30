using System.Collections.Generic;
using Task_02.Entities;
using Task_02.Printers.Abstract.NumberOfMatches;

namespace Task_02.Statistics.Abstract.NumberOfMatches
{
    internal class HeroUsagesStatisticMostUnfavoriteProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostUnfavoriteProvider(List<HeroScoreInfo> infos) : base(infos, new UnfavoritePrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostUnfavouriteHeros(Infos));
        }
    }
}