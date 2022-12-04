using System;

namespace AdventOfCode2022
{
    public class DayFourTask
    {
        public static string[] GetDay4Input()
        {
            string text = System.IO.File.ReadAllText(@"D:\AdventOfCode2022\AdventOfCode2022\Inputs\Day4Input.txt");
            return text.Split(
                    new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public static int CountIfOneRangeContainAnother(string[] input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                (int s1, int e1, int s2, int e2) = GetRangeFromString(input[i]);

                if (OneRangeContainsAnother(s1, e1, s2, e2))
                    ++sum;
            }

            return sum;
        }

        public static int CountIfOneRangeOverlapsAnother(string[] input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                (int s1, int e1, int s2, int e2) = GetRangeFromString(input[i]);

                if (OneRangeOverlapsAnother(s1, e1, s2, e2))
                    ++sum;
            }

            return sum;
        }

        public static bool OneRangeOverlapsAnother(int start1, int end1, int start2, int end2)
        {
            //now I don't support reverse ranges
            if (!RangeCorrect(start1, end1) || !RangeCorrect(start2, end2))
                throw new Exception();

            bool oneOverlapsTwo = start1 <= start2 && end1 >= start2;
            bool twoOverlapsOne = start2 <= start1 && end2 >= start1;

            return oneOverlapsTwo || twoOverlapsOne;
        }

        public static bool OneRangeContainsAnother(int start1, int end1, int start2, int end2)
        {
            //now I don't support reverse ranges
            if (!RangeCorrect(start1, end1) || !RangeCorrect(start2, end2))
                throw new Exception();

            bool oneContainsTwo = start1 <= start2 && end1 >= end2;
            bool twoContainsOne = start2 <= start1 && end2 >= end1;

            return oneContainsTwo || twoContainsOne;
        }

        static bool RangeCorrect(int start, int end)
        {
            return start <= end;
        }

        static (int, int, int, int) GetRangeFromString(string row)
        {
            string[] range = row.Split(new string[] { "-", "," }, StringSplitOptions.None);
            int start1, start2, end1, end2;

            if (!(range.Length == 4))
                throw new Exception();


            if (int.TryParse(range[0], out start1) && int.TryParse(range[1], out end1)
                    && int.TryParse(range[2], out start2) && int.TryParse(range[3], out end2))
            {
                return (start1, end1, start2, end2);
            }
            else
                throw new Exception();
        }
    }
}