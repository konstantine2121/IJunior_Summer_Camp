using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using Task_02.Entities;

[assembly: InternalsVisibleTo("Task_02_UnitTests")]
namespace Task_02.Statistics
{
    internal class HeroUsagesStatisticCalculator
    {
        #region Find Successful 

        public List<HeroScoreInfo> FindMostSuccessfulHeroes(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHeroesByCondition(heroScoreInfos, ScoreInfoCalculator.CalculateWinRate, SortOrder.Descending);
        }

        public List<HeroScoreInfo> FindMostUnsuccessfulHeroes(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHeroesByCondition(heroScoreInfos, ScoreInfoCalculator.CalculateWinRate, SortOrder.Ascending);
        }

        #endregion Find Successful

        #region Find Favourite

        public List<HeroScoreInfo> FindMostFavoriteHeroes(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHeroesByCondition(heroScoreInfos, ScoreInfoCalculator.CalculateNumberOfPlayedMatches, SortOrder.Descending);
        }

        public List<HeroScoreInfo> FindMostUnfavoriteHeroes(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHeroesByCondition(heroScoreInfos, ScoreInfoCalculator.CalculateNumberOfPlayedMatches, SortOrder.Ascending);
        }

        #endregion Find Favourite

        #region Find WinStreak

        public List<HeroScoreInfo> FindMostWinStreakHeroes(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHeroesByCondition(heroScoreInfos, ScoreInfoCalculator.CalculateWinStreak, SortOrder.Descending);
        }

        #endregion Find WinStreak

        #region Private Members

        private List<HeroScoreInfo> FindHeroesByCondition(IEnumerable<HeroScoreInfo> heroScoreInfos, Func<HeroScoreInfo, double> infoSelector, SortOrder sortOrder)
        {
            if (heroScoreInfos == null || !heroScoreInfos.Any())
            {
                return new List<HeroScoreInfo>();
            }

            var infos = heroScoreInfos.ToList();
            var cashedInfoValues = CashInfoValues(infos, infoSelector);
            IOrderedEnumerable<HeroScoreInfo> orderedInfos = OrderInfos(infos, cashedInfoValues, sortOrder);
            var targetValue = cashedInfoValues[orderedInfos.First()];

            return SelectTargetRecords(orderedInfos, cashedInfoValues, targetValue); ;
        }

        private static Dictionary<HeroScoreInfo, double> CashInfoValues(IEnumerable<HeroScoreInfo> heroScoreInfos, Func<HeroScoreInfo, double> infoSelector)
        {
            var cashedInfos = new Dictionary<HeroScoreInfo, double>();

            foreach (var hero in heroScoreInfos)
            {
                if (!cashedInfos.ContainsKey(hero))
                {
                    cashedInfos.Add(hero, infoSelector(hero));
                }
            }

            return cashedInfos;
        }

        private static IOrderedEnumerable<HeroScoreInfo> OrderInfos(List<HeroScoreInfo> infos, Dictionary<HeroScoreInfo, double> cashedInfos, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Ascending ?
                infos.OrderBy(info => cashedInfos[info]) :
                infos.OrderByDescending(info => cashedInfos[info]);
        }

        private static List<HeroScoreInfo> SelectTargetRecords(IOrderedEnumerable<HeroScoreInfo> orderedInfos, Dictionary<HeroScoreInfo, double> cashedInfos, double targetValue)
        {
            var result = new List<HeroScoreInfo>();

            foreach (var info in orderedInfos)
            {
                if (cashedInfos[info] != targetValue)
                {
                    break;
                }

                result.Add(info);
            }

            return result;
        }

        #endregion Private Members
    }
}
