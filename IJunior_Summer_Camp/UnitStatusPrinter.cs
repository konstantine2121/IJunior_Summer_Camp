using System;

namespace Task_01
{
    internal class UnitStatusPrinter
    {
        private readonly Unit _unit;
        private int _lineCounter = 0;

        private const int NameOffset = -10;

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
            PrintInfo($"{"Имя:",NameOffset} {_unit.Name}");
        }

        private void PrintFaction()
        {
            PrintInfo($"{"Фракция:",NameOffset} {_unit.Faction}");
        }

        private void PrintHealth()
        {
            PrintInfo($"{"Здоровье:",NameOffset} {FormatDouble(_unit.Health)}");
        }

        private void PrintDamage()
        {
            PrintInfo($"{"Урон:",NameOffset} {FormatDouble(_unit.Damage)}");
        }

        private void PrintBerserkMode()
        {
            PrintInfo($"{"Ярость:",NameOffset} {_unit.BerserkMode}");
        }

        private void PrintArmor()
        {
            PrintInfo($"{"Броня:",NameOffset} {_unit.Armor}");
        }

        private void PrintInfo(string info)
        {
            SetCursor();
            Console.WriteLine(info);
            IncrementLineCounter();
        }

        #region CursorMovement

        private string FormatDouble(double value)
        {
            return value.ToString("0.000");
        }

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
