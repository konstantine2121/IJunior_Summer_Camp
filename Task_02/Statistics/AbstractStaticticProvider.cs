using System.Collections.Generic;

namespace Task_02.Statistics
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
