using System;

namespace AdventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            DayFourResults();
        }

        static void DayFourResults()
        {
            string[] input = DayFourTask.GetDay4Input();
            //First task
            Console.WriteLine($"The result of first task of day 4 is: {DayFourTask.CountIfOneRangeContainAnother(input)}");

            //Second task
            Console.WriteLine($"The result of second task of day 4 is: {DayFourTask.CountIfOneRangeOverlapsAnother(input)}");
        }
    }
}
