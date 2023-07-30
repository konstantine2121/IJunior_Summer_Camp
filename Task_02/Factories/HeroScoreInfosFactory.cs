using System.Collections.Generic;
using Task_02.Entities;
using Task_02.Enums;

namespace Task_02.Factories
{
    internal class HeroScoreInfosFactory
    {
        public List<HeroScoreInfo> CreateScoreInfos()
        {
            var result = new List<HeroScoreInfo>();

            result.Add(new HeroScoreInfo(new Hero(HeroNames.Luzanna),
                new List<bool>() { false, true, true }));

            result.Add(new HeroScoreInfo(new Hero(HeroNames.Corkes),
                new List<bool>() { true, true, true, false, true }));

            result.Add(new HeroScoreInfo(new Hero(HeroNames.Nova),
                new List<bool>() { true, true, false, true, true, true, false }));

            result.Add(new HeroScoreInfo(new Hero(HeroNames.Yun_Jin),
                new List<bool>() { true, false, false }));

            result.Add(new HeroScoreInfo(new Hero(HeroNames.Reiko),
                new List<bool>() { false, false, true, true, false }));

            return result;
        }
    }
}
