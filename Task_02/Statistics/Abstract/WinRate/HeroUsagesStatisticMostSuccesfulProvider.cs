using System.Collections.Generic;
using Task_02.Entities;
using Task_02.Printers.Abstract.WinRate;

namespace Task_02.Statistics.Abstract.WinRate
{
    internal class HeroUsagesStatisticMostSuccessfulProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostSuccessfulProvider(List<HeroScoreInfo> infos) : base(infos, new WinRateSuccessfulPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostSuccessfulHeros(Infos));
        }
    }
}