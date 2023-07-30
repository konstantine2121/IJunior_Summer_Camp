using System.Collections.Generic;
using Task_02.Printers.Abstract.WinRate;

namespace Task_02.Statistics.Abstract.WinRate
{
    internal class HeroUsagesStatisticMostUnsuccessfulProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostUnsuccessfulProvider(List<HeroScoreInfo> infos) : base(infos, new WinRateUnsuccessfulPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostUnsuccessfulHeros(Infos));
        }
    }
}