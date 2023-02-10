using System;

namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayFirstDayResults();
        }

        private static void DisplayFirstDayResults()
        {
            string[] input = Day1.CalorieCounting.GetInput();

            int res1 = Day1.CalorieCounting.GetFirstTaskResult(input);
            int res2 = Day1.CalorieCounting.GetSecondTaskResult(input);

            Helper.DisplayResultsOnConsole(1, res1, res2);
        }
    }
}
