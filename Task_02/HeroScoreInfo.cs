using System.Collections.Generic;

namespace Task_02
{
    internal class HeroScoreInfo
    {
        private readonly List<bool> _records;

        public HeroScoreInfo(Hero hero, IEnumerable<bool> records)
        {
            Hero = hero;
            _records = new List<bool>(records);
        }

        public Hero Hero { get; }

        public string HeroName => Hero.Name;
        
        public IReadOnlyList<bool> Records => _records;

        public double GetWinRate() => MatchScoreInfoCalculator.CalculateWinRate(this);

        public int GetNumberOfPlayedMatches() => (int) MatchScoreInfoCalculator.CalculateNumberOfPlayedMatches(this);

        public int GetWinStreak() => (int)MatchScoreInfoCalculator.CalculateWinStreak(this);
    }
}
