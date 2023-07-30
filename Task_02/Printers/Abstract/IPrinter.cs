using System.Collections.Generic;
using Task_02.Entities;

namespace Task_02.Printers.Abstract
{
    internal interface IPrinter
    {
        void Print(IEnumerable<HeroScoreInfo> heroes);
    }
}
