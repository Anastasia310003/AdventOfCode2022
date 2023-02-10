using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Day1
{
    public static class CalorieCounting
    {
        public static string[] GetInput()
        {
            return System.IO.File.ReadAllLines(
            Path.Combine(Helper.GetBaseDirectory(), @"AdventOfCode2022\AdventOfCode2022\Day1\Input.txt")
            );
        }

        public static int GetFirstTaskResult(string[] input)
        {
            return GetTotalCaloriesPerElvSortedList(input).First();
        }

        public static int GetSecondTaskResult(string[] input)
        {
            List<int> caloriesList = GetTotalCaloriesPerElvSortedList(input);

            return caloriesList.Take(3).Sum();
        }

        /// <summary>
        /// Parses the input and sums the calories per each elv. List is sorted by desc
        /// </summary>
        /// <param name="input">List of snacks calories carried by each elv</param>
        /// <returns>Sorted by desc list of total calories carried by elv</returns>
        private static List<int> GetTotalCaloriesPerElvSortedList(string[] input)
        {
            var processedInfoList = new List<int>();
            int tempSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(input[i]))
                {
                    int.TryParse(input[i], out int tempParsedInt);
                    tempSum += tempParsedInt;
                }
                else
                {
                    processedInfoList.Add(tempSum);
                    tempSum = 0;
                }

                if (i == input.Length - 1)
                    processedInfoList.Add(tempSum);
            }

            processedInfoList.Sort((x, y) => y.CompareTo(x));

            return processedInfoList;
        }
    }
}
