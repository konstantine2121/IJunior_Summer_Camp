using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Task_02
{
    internal class HeroUsagesStatisticCalculator
    {
        #region Find Successful 

        public IEnumerable<HeroScoreInfo> FindMostSuccessfulHeros(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHerosByCondition(heroScoreInfos, MatchScoreInfoCalculator.CalculateWinRate, SortOrder.Descending);
        }

        public IEnumerable<HeroScoreInfo> FindMostUnsuccessfulHeros(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHerosByCondition(heroScoreInfos, MatchScoreInfoCalculator.CalculateWinRate, SortOrder.Ascending);
        }

        #endregion Find Successful

        #region Find Favourite

        public IEnumerable<HeroScoreInfo> FindMostFavoriteHeros(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHerosByCondition(heroScoreInfos, MatchScoreInfoCalculator.CalculateNumberOfPlayedMatches, SortOrder.Descending);
        }

        public IEnumerable<HeroScoreInfo> FindMostUnfavoriteHeros(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHerosByCondition(heroScoreInfos, MatchScoreInfoCalculator.CalculateNumberOfPlayedMatches, SortOrder.Ascending);
        }

        #endregion Find Favourite

        #region Find WinStreak

        public IEnumerable<HeroScoreInfo> FindMostWinStreakHeros(IEnumerable<HeroScoreInfo> heroScoreInfos)
        {
            return FindHerosByCondition(heroScoreInfos, MatchScoreInfoCalculator.CalculateWinStreak, SortOrder.Descending);
        }

        #endregion Find WinStreak

        private IEnumerable<HeroScoreInfo> FindHerosByCondition(IEnumerable<HeroScoreInfo> heroScoreInfos, Func<HeroScoreInfo, double> infoSelector, SortOrder sortOrder)
        {
            if (heroScoreInfos == null || !heroScoreInfos.Any())
            {
                return Enumerable.Empty<HeroScoreInfo>();
            }

            var cashedInfos = CalculateInfo(heroScoreInfos, infoSelector);
            var infos = heroScoreInfos.ToList();
            IOrderedEnumerable<HeroScoreInfo> ordered;

            if (sortOrder == SortOrder.Ascending)
            {
                ordered = infos.OrderBy(info => cashedInfos[info]);
            }
            else
            {
                ordered = infos.OrderByDescending(info => cashedInfos[info]);
            }

            var targetValue = cashedInfos[ordered.First()];

            return infos.Where(info => cashedInfos[info] == targetValue).ToList();
        }

        #region Calculate Info

        private static Dictionary<HeroScoreInfo, double> CalculateInfo(IEnumerable<HeroScoreInfo> heroScoreInfos, Func<HeroScoreInfo, double> infoSelector)
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

        #endregion Calculate Info
    }
}
