using System.Collections.Generic;
using Task_02.Printers.Abstract.WinRate;

namespace Task_02.Statistics
{
    internal class HeroUsagesStatisticMostSuccessfulProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostSuccessfulProvider(List<HeroScoreInfo> infos) : base (infos, new WinRateSuccessfulPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostSuccessfulHeros(Infos));
        }
    }
}