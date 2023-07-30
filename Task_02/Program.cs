using System;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new HeroScoreInfosFactory();
            var infos = factory.CreateScoreInfos();
            var usagesStatisticProvider = new HeroUsagesStatisticProvider();

            var successful = usagesStatisticProvider.FindMostSuccessfulHeros(infos);
            var unsuccessful = usagesStatisticProvider.FindMostUnsuccessfulHeros(infos);
            var favourite = usagesStatisticProvider.FindMostFavouriteHeros(infos);
            var unfavourite = usagesStatisticProvider.FindMostUnfavouriteHeros(infos);
            var winStreak = usagesStatisticProvider.FindMostWinStreakHeros(infos);

            var printer = new HeroUsagesStatisticPrinter();

            printer.PrintSuccessful(successful);
            printer.PrintUnsuccessful(unsuccessful);
            printer.PrintFavourite(favourite);
            printer.PrintUnfavourite(unfavourite);
            printer.PrintWinStreak(winStreak);

            Console.ReadLine();

        }
    }
}
