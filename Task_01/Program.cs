using System;
using System.Threading;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new UnitFactory();

            var unit1 = factory.CreateUnit("Петя");
            var unit2 = factory.CreateUnit("Эльф");

            var infoPrinter1 = new UnitStatusPrinter(0, 0, unit1);
            var infoPrinter2 = new UnitStatusPrinter(0, 40, unit2);

            PrintInfo(infoPrinter1, infoPrinter2);
            PrepareToBattle();

            while (unit1.Alive && unit2.Alive)
            {
                PerformAttack(unit1, unit2);
                PrintInfo(infoPrinter1, infoPrinter2);

                Thread.Sleep(1000);
            }

            ShowBattleResult(unit1, unit2);

            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();
        }

        private static void ShowBattleResult(Unit unit1, Unit unit2)
        {
            if (!unit1.Alive && !unit2.Alive)
            {
                Console.WriteLine("Ничья.");
            }
            else
            {
                if (unit1.Alive)
                {
                    Console.WriteLine($"{unit1.Name} победил!");
                }
                else
                {
                    Console.WriteLine($"{unit2.Name} победил!");
                }
            }
        }

        private static void PrepareToBattle()
        {
            Console.WriteLine("\nНажмите Enter для начала боя.");
            Console.ReadLine();
            Console.Clear();
        }

        private static void PerformAttack(Unit unit1, Unit unit2)
        {
            unit1.Attack(unit2);
            unit2.Attack(unit1);
        }

        private static void PrintInfo(UnitStatusPrinter infoPrinter1, UnitStatusPrinter infoPrinter2)
        {
            infoPrinter1.Print();
            infoPrinter2.Print();
        }
    }
}
