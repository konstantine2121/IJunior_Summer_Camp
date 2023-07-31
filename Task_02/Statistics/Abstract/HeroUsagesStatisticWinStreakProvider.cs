using System.Collections.Generic;
using Task_02.Entities;
using Task_02.Printers.Abstract;

namespace Task_02.Statistics.Abstract
{
    internal class HeroUsagesStatisticWinStreakProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticWinStreakProvider(List<HeroScoreInfo> infos) : base(infos, new WinStrickPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostWinStreakHeroes(Infos));
        }
    }
}