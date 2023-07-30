using System.Collections.Generic;

namespace Task_02.Printers.Abstract.WinRate
{
    internal abstract class WinRatePrinter : IPrinter
    {
        private string _winRateFormat = " {0} (винрейт {1:0.00})";

        public abstract void Print(IEnumerable<HeroScoreInfo> heroes);

        protected string GetWinRateString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(_winRateFormat, heroScoreInfo.HeroName, heroScoreInfo.GetWinRate());
        }
    }
}