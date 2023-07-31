using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_02.Entities;
using Task_02.Enums;
using Task_02.Statistics;

namespace Task_02_UnitTests
{
    [TestClass]
    public class HeroUsagesStatisticCalculatorTests
    {
        private HeroUsagesStatisticCalculator _calculator;
        private List<HeroScoreInfo> _heroes;

        [TestInitialize()]
        public void TestInitialize()
        {
            _calculator = new HeroUsagesStatisticCalculator();
            _heroes = new List<HeroScoreInfo>()
            {
                new HeroScoreInfo(
                    new Hero(HeroNames.Luzanna),
                    new List<bool>() { false, true, true }
                ),
                new HeroScoreInfo(
                    new Hero(HeroNames.Corkes),
                    new List<bool>() { true, true, true, false, true }
                ),
                new HeroScoreInfo(
                    new Hero(HeroNames.Nova),
                    new List<bool>() { true, true, false, true, true, true, false }
                ),
                new HeroScoreInfo(
                    new Hero(HeroNames.Yun_Jin),
                    new List<bool>() { true, false, false }
                ),
                new HeroScoreInfo(
                    new Hero(HeroNames.Reiko),
                    new List<bool>() { false, false, true, true, false }
                )
            };
        }

        [TestMethod]
        public void FindMostSuccessfulHeroesTest()
        {
            // arrange
            const string expectedHero = HeroNames.Corkes;

            // act
            var successfulHeroes = _calculator.FindMostSuccessfulHeroes(_heroes);

            // assert
            if (successfulHeroes.Count == 0
                || successfulHeroes.Count > 1)
            {
                Assert.Fail();
            }

            Assert.AreEqual(expectedHero, successfulHeroes.First().HeroName);
        }

        [TestMethod]
        public void FindMostUnsuccessfulHeroesTest()
        {
            // arrange
            const string expectedHero = HeroNames.Yun_Jin;

            // act
            var unsuccessfulHeroes = _calculator.FindMostUnsuccessfulHeroes(_heroes);

            // assert
            if (unsuccessfulHeroes.Count == 0
                || unsuccessfulHeroes.Count > 1)
            {
                Assert.Fail();
            }

            Assert.AreEqual(expectedHero, unsuccessfulHeroes.First().HeroName);
        }

        [TestMethod]
        public void FindMostFavoriteHeroesTest()
        {
            // arrange
            const string expectedHero = HeroNames.Nova;

            // act
            var favoriteHeroes = _calculator.FindMostFavoriteHeroes(_heroes);

            // assert
            if (favoriteHeroes.Count == 0
                || favoriteHeroes.Count > 1)
            {
                Assert.Fail();
            }

            Assert.AreEqual(expectedHero, favoriteHeroes.First().HeroName);
        }

        [TestMethod]
        public void FindMostUnfavoriteHeroesTest()
        {
            // arrange
            var expectedHeroes = new List<string>()
            {
                HeroNames.Luzanna,
                HeroNames.Yun_Jin
            };

            // act
            var unfavoriteHeroes = _calculator.FindMostUnfavoriteHeroes(_heroes);

            // assert
            if (!unfavoriteHeroes.Any())
            {
                Assert.Fail();
            }

            foreach (HeroScoreInfo hero in unfavoriteHeroes)
            {
                Assert.IsTrue(expectedHeroes.Contains(hero.HeroName));
            }
        }

        [TestMethod]
        public void FindMostWinStreakHeroes()
        {
            // arrange
            var expectedHeroes = new List<string>()
            {
                HeroNames.Corkes,
                HeroNames.Nova
            };

            // act
            var winstreakHeroes = _calculator.FindMostWinStreakHeroes(_heroes);

            // assert
            if (!winstreakHeroes.Any())
            {
                Assert.Fail();
            }

            foreach (HeroScoreInfo hero in winstreakHeroes)
            {
                Assert.IsTrue(expectedHeroes.Contains(hero.HeroName));
            }
        }
    }
}
