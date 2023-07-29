using System;

namespace Task_01
{
    internal class UnitStatusPrinter
    {
        private readonly Unit _unit;
        private int _lineCounter = 0;

        public UnitStatusPrinter(int cursorTop, int cursorLeft, Unit unit)
        {
            CursorTop = cursorTop;
            CursorLeft = cursorLeft;
            _unit = unit;
        }

        public int CursorTop { get; }

        public int CursorLeft { get; }

        public void Print()
        {
            _lineCounter = 0;
            PrintName();
            PrintFaction();
            PrintHealth();
            PrintArmor();
            PrintDamage();
            PrintBerserkMode();
        }

        private void PrintName()
        {
            SetCursor();
            Console.WriteLine($"Имя: {_unit.Name}");
            IncrementLineCounter();
        }

        private void PrintFaction()
        {
            SetCursor();
            Console.WriteLine($"Фракция: {_unit.Faction}");
            IncrementLineCounter();
        }

        private void PrintHealth()
        {
            SetCursor();
            Console.WriteLine($"Здоровье: {_unit.Health}");
            IncrementLineCounter();
        }

        private void PrintDamage()
        {
            SetCursor();
            Console.WriteLine($"Урон: {_unit.Damage}");
            IncrementLineCounter();
        }

        private void PrintBerserkMode()
        {
            SetCursor();
            Console.WriteLine($"Ярость: {_unit.BerserkMode}");
            IncrementLineCounter();
        }

        private void PrintArmor()
        {
            SetCursor();
            Console.WriteLine($"Броня: {_unit.Armor}");
            IncrementLineCounter();
        }



        #region CursorMovement

        private void SetCursor()
        {
            var top = CursorTop + _lineCounter;
            Console.SetCursorPosition(CursorLeft, top);
        }

        private void IncrementLineCounter()
        {
            _lineCounter++;
        }

        #endregion CursorMovement
    }
}
