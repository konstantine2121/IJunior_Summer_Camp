using System.Collections.Generic;

namespace Task_02.Statistics
{
    internal interface IPrinter
    {
        void Print(IEnumerable<HeroScoreInfo> heroes);
    }
}
