using System;

namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayFirstDayResults();
            DisplaySecondDayResults();
        }

        private static void DisplayFirstDayResults()
        {
            string[] input = Day1.CalorieCounting.GetInput();

            int res1 = Day1.CalorieCounting.GetFirstTaskResult(input);
            int res2 = Day1.CalorieCounting.GetSecondTaskResult(input);

            Helper.DisplayResultsOnConsole(1, res1, res2);
        }

        private static void DisplaySecondDayResults()
        {
            string[] input = Day2.Game.GetInput();

            int res1 = Day2.Game.GetFirstTaskResult(input);

            Helper.DisplayResultsOnConsole(2, res1, 0);
        }
    }
}
