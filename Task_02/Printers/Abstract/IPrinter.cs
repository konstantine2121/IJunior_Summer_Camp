using System.Collections.Generic;

namespace Task_02.Printers.Abstract
{
    internal interface IPrinter
    {
        void Print(IEnumerable<HeroScoreInfo> heroes);
    }
}
