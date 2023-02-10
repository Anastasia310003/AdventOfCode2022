using System;

namespace AdventOfCode2022
{
    public static class Helper
    {
        public static string GetBaseDirectory()
        {
            return @"D:\";
        }

        public static void DisplayResultsOnConsole(int day, int res1, int res2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Results of day {day} tasks:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Task 1: {res1}");
            Console.WriteLine($"Task 2: {res2}");
        }
    }
}