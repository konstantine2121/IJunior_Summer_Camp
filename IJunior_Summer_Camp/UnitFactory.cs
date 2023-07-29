using System;
using System.Linq;

namespace Task_01
{
    internal class UnitFactory
    {
        private static Random _random = new Random();

        private readonly Factions[] _factions = Enum.GetValues(typeof(Factions))
            .Cast<Factions>()
            .ToArray(); 

        public Unit CreateUnit(string name)
        {
            return new Unit(
                name,
                GetFaction(),
                GetHealth(),
                GetDamage(),
                GetBerserkMode(),
                GetArmor());
        }

        private double GetHealth()
        {
            var min = 50;
            var max = 100;
            var delta = max - min;
            return  min + _random.NextDouble()*delta;
        }

        private double GetDamage()
        {
            var min = 5;
            var max = 50;
            var delta = max - min;
            return min + _random.NextDouble() * delta;
        }

        private Factions GetFaction()
        {
            var index = _random.Next(_factions.Length);
            return _factions[index];
        }

        private int GetArmor()
        {
            var min = 0;
            var max = 100;
            return _random.Next(min, max + 1);
        }

        private bool GetBerserkMode()
        {
            var numberOfValues = 2;
            return _random.Next(numberOfValues) == 1 ?
                true : 
                false;
        }
    }
}
