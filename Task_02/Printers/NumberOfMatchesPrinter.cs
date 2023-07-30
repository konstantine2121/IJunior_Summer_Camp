using System.Collections.Generic;
using Task_02.Statistics;

namespace Task_02.Printers
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