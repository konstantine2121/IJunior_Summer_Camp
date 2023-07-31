using System;
using Task_02.Factories;
using Task_02.Printers.Certain;
using Task_02.Statistics;
using Task_02.Statistics.Abstract;
using Task_02.Statistics.Abstract.NumberOfMatches;
using Task_02.Statistics.Abstract.WinRate;
using Task_02.Statistics.Certain;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunUnsafeDataBindingExample();
            Console.WriteLine();
            RunSafeDataBindingExample();
            Console.WriteLine();
            RunAbstractDataBindingExample();

            Console.ReadLine();
        }

        private static void RunUnsafeDataBindingExample()
        {
            var factory = new HeroScoreInfosFactory();
            var infos = factory.CreateScoreInfos();
            var usagesStatisticCalculator = new HeroUsagesStatisticCalculator();

            var successful = usagesStatisticCalculator.FindMostSuccessfulHeroes(infos);
            var unsuccessful = usagesStatisticCalculator.FindMostUnsuccessfulHeroes(infos);
            var favorite = usagesStatisticCalculator.FindMostFavoriteHeroes(infos);
            var unfavorite = usagesStatisticCalculator.FindMostUnfavoriteHeroes(infos);
            var winStreak = usagesStatisticCalculator.FindMostWinStreakHeroes(infos);

            var printer = new HeroUsagesStatisticPrinter();

            printer.PrintSuccessful(successful);
            printer.PrintUnsuccessful(unsuccessful);
            //printer.PrintUnsuccessful(successful); // Incorrect data printing!!!!
            printer.PrintFavorite(favorite);
            printer.PrintUnfavorite(unfavorite);
            printer.PrintWinStreak(winStreak);
        }

        private static void RunSafeDataBindingExample()
        {
            var factory = new HeroScoreInfosFactory();
            var infos = factory.CreateScoreInfos();
            var provider = new HeroUsagesStatisticProvider(infos);

            provider.ShowMostSuccessfulHeros();
            provider.ShowMostUnsuccessfulHeros();
            provider.ShowMostFavoriteHeros();
            provider.ShowMostUnfavoriteHeros();
            provider.ShowMostWinStreakHeros();
        }

        private static void RunAbstractDataBindingExample()
        {
            var factory = new HeroScoreInfosFactory();
            var infos = factory.CreateScoreInfos();

            AbstractStatisticProvider[] providers = new AbstractStatisticProvider[]
            {
                new HeroUsagesStatisticMostSuccessfulProvider(infos),
                new HeroUsagesStatisticMostUnsuccessfulProvider(infos),
                new HeroUsagesStatisticMostFavoriteProvider(infos),
                new HeroUsagesStatisticMostUnfavoriteProvider(infos),
                new HeroUsagesStatisticWinStreakProvider(infos)
            };

            foreach (AbstractStatisticProvider provider in providers)
            {
                provider.Show();
            }
        }
    }
}
