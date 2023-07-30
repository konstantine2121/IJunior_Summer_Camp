using System.Collections.Generic;

namespace Task_02
{
    internal interface IPrinter
    {
        void Print(IEnumerable<HeroScoreInfo> heroes);
    }
}
