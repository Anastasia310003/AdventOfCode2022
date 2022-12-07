using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day6
{
    public class DaySixTask
    {
        public static string GetDay6Input()
        {
            return System.IO.File.ReadAllText(@"D:\AdventOfCode2022\AdventOfCode2022\Inputs\Day6Input.txt");
        }

        public static int RunDay6TaskFirstPart(string input)
        {
            return FindPosition(input, 4);
        }

        public static int RunDay6TaskSecondPart(string input)
        {
            return FindPosition(input, 14);
        }

        /// <summary>
        /// Finds position of the next char after 4 previous being different from each other. Otherwise, returns 0;
        /// </summary>
        /// <param name="input">string input</param>
        static int FindPosition(string input, int lengthOfDistinctChars)
        {
            char[] checkArr = new char[lengthOfDistinctChars];
            int checkArrIndex = 0;
            int resultPosition = 0;

            for(int i = 0; i < input.Length; ++i)
            {
                if (checkArrIndex == lengthOfDistinctChars)
                    checkArrIndex = 0;

                if (checkArr[checkArrIndex] != '\0' && CheckIfAllFourCharsAreDifferent(checkArr))
                {
                    resultPosition = i;
                    break;
                }
                else
                {
                    checkArr[checkArrIndex] = input[i];
                    checkArrIndex++;
                }
            }

            return resultPosition;
        }

        static bool CheckIfAllFourCharsAreDifferent(char[] arr)
        {
            HashSet<char> s = new HashSet<char>(arr);

            return (s.Count == arr.Length);
        }
    }
}
