using System.Collections.Generic;
using Task_02.Printers;

namespace Task_02.Statistics
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