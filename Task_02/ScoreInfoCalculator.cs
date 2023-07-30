using System.Linq;
using Task_02.Entities;

namespace Task_02
{
    internal static class ScoreInfoCalculator
    {
        public static double CalculateWinRate(HeroScoreInfo info)
        {
            var wins = info.Records.Where(record => record).Count();
            double total = info.Records.Count;

            return wins / total;
        }

        public static double CalculateNumberOfPlayedMatches(HeroScoreInfo info)
        {
            return info.Records.Count;
        }

        public static double CalculateWinStreak(HeroScoreInfo info)
        {
            var records = info.Records;
            var maxStreak = 0;
            var currentStreak = 0;

            foreach (var record in records) 
            {
                if (record)
                {
                    currentStreak++;

                    if (currentStreak > maxStreak)
                    {
                        maxStreak = currentStreak;
                    }
                }
                else
                {
                    currentStreak = 0;
                }
            }

            return maxStreak;
        }
    }
}
