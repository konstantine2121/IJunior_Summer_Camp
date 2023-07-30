using System;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunUnsafeDataBindingExample();
            RunSafeDataBindingExample();

            Console.ReadLine();
        }

        private static void RunUnsafeDataBindingExample()
        {
            var factory = new HeroScoreInfosFactory();
            var infos = factory.CreateScoreInfos();
            var usagesStatisticCalculator = new HeroUsagesStatisticCalculator();

            var successful = usagesStatisticCalculator.FindMostSuccessfulHeros(infos);
            var unsuccessful = usagesStatisticCalculator.FindMostUnsuccessfulHeros(infos);
            var favourite = usagesStatisticCalculator.FindMostFavouriteHeros(infos);
            var unfavourite = usagesStatisticCalculator.FindMostUnfavouriteHeros(infos);
            var winStreak = usagesStatisticCalculator.FindMostWinStreakHeros(infos);

            var printer = new HeroUsagesStatisticPrinter();

            printer.PrintSuccessful(successful);
            printer.PrintUnsuccessful(unsuccessful);
            //printer.PrintUnsuccessful(successful); // Incorrect data printing!!!!
            printer.PrintFavourite(favourite);
            printer.PrintUnfavourite(unfavourite);
            printer.PrintWinStreak(winStreak);
        }

        private static void RunSafeDataBindingExample()
        {
            var factory = new HeroScoreInfosFactory();
            var infos = factory.CreateScoreInfos();
            var provider = new HeroUsagesStatisticProvider(infos);

            provider.ShowMostSuccessfulHeros();
            provider.ShowMostUnsuccessfulHeros();
            provider.ShowMostFavouriteHeros();
            provider.ShowMostUnfavouriteHeros();
            provider.ShowMostWinStreakHeros();
        }
    }
}
