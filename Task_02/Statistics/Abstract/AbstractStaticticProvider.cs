using System.Collections.Generic;
using Task_02.Printers.Abstract;

namespace Task_02.Statistics.Abstract
{
    internal abstract class AbstractStatisticProvider
    {
        protected readonly List<HeroScoreInfo> Infos;
        protected readonly IPrinter Printer;
        protected readonly HeroUsagesStatisticCalculator Calculator = new HeroUsagesStatisticCalculator();

        public AbstractStatisticProvider(List<HeroScoreInfo> infos, IPrinter printer)
        {
            Infos = infos;
            Printer = printer;
        }

        internal abstract void Show();
    }
}
