using System.Collections.Generic;
using Task_02.Printers;

namespace Task_02.Statistics
{
    internal class HeroUsagesStatisticWinStreakProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticWinStreakProvider(List<HeroScoreInfo> infos) : base(infos, new WinStrickPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostWinStreakHeros(Infos));
        }
    }
}