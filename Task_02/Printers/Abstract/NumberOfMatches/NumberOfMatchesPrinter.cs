using System.Collections.Generic;

namespace Task_02.Printers.Abstract.NumberOfMatches
{
    internal abstract class NumberOfMatchesPrinter : IPrinter
    {
        private string _matchesFormat = " {0} ({1} матчей)";

        public abstract void Print(IEnumerable<HeroScoreInfo> heroes);

        protected string GetMatchesString(HeroScoreInfo heroScoreInfo)
        {
            return string.Format(_matchesFormat, heroScoreInfo.HeroName, heroScoreInfo.GetNumberOfPlayedMatches());
        }
    }
}