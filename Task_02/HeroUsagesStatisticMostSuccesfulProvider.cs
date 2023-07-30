using System.Collections.Generic;

namespace Task_02
{
    internal class HeroUsagesStatisticMostSuccessfulProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostSuccessfulProvider(List<HeroScoreInfo> infos) : base (infos, new WinRateSuccessfulPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostSuccessfulHeros(Infos));
        }
    }

    internal class HeroUsagesStatisticMostUnsuccessfulProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostUnsuccessfulProvider(List<HeroScoreInfo> infos) : base (infos, new WinRateUnsuccessfulPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostUnsuccessfulHeros(Infos));
        }
    }

    internal class HeroUsagesStatisticMostFavoriteProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostFavoriteProvider(List<HeroScoreInfo> infos) : base (infos, new FavoritePrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostFavoriteHeros(Infos));
        }
    }

    internal class HeroUsagesStatisticMostUnfavoriteProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticMostUnfavoriteProvider(List<HeroScoreInfo> infos) : base(infos, new UnfavoritePrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostUnfavoriteHeros(Infos));
        }
    }

    internal class HeroUsagesStatisticWinStreakProvider : AbstractStatisticProvider
    {
        public HeroUsagesStatisticWinStreakProvider(List<HeroScoreInfo> infos) : base(infos, new WinStrickPrinter()) { }

        internal override void Show()
        {
            Printer.Print(Calculator.FindMostWinStreakHeros(Infos));
        }
    }
}