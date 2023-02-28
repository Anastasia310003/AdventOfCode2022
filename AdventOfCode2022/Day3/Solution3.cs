using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Day3
{
    public static class Solution3
    {
        public static string[] GetInput()
        {
            return System.IO.File.ReadAllLines(
            Path.Combine(Helper.GetBaseDirectory(), @"AdventOfCode2022\AdventOfCode2022\Day3\Input.txt")
            );
        }

        public static int GetFirstTaskResult(string[] input)
        {
            int sum = 0;

            foreach (string row in input)
            {
                if (!IsRowValid(row))
                    throw new ArgumentException($"Day3.Solution3.GetFirstTaskResult -> The row should have even length. Row value:{ row }.");

                Tuple<string, string> devidedString = DevideStringInTwo(row);
                List<char> commonChars = FindCommonChars(devidedString.Item1, devidedString.Item2);
                int priority = GetPriority(commonChars.First());
                sum += priority;
            }

            return sum;
        }

        public static int GetSecondTaskResult(string[] input)
        {
            int sum = 0;

            for(int i = 0; i  < input.Length; ++ i)
            {
                List<char> commonChars = FindCommonChars(input[i], input[++i], input[++i]);
                int priority = GetPriority(commonChars.First());
                sum += priority;
            }

            return sum;
        }

        private static int GetPriority(char letter)
        {
            if (letter >= 'A' && letter <= 'Z')
                return letter - 38;
            else if (letter >= 'a' && letter <= 'z')
                return letter - 96;
            else
                throw new ArgumentException($"Day3.Solution3.GetPriority -> Invalid argument passed. Argument value:{ letter }.");
        }

        private static Tuple<string, string> DevideStringInTwo(string row)
        {
            return new Tuple<string, string>(row.Substring(0, row.Length / 2), row.Substring(row.Length / 2));
        }

        private static List<char> FindCommonChars(string one, string two)
        {
            return one.Intersect(two).ToList();
        }

        private static List<char> FindCommonChars(string one, string two, string three)
        {
            return one.Intersect(two).Intersect(three).ToList();
        }

        private static bool IsRowValid(string row)
        {
            return row.Length % 2 == 0;
        }
    }
}
