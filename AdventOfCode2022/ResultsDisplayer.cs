namespace AdventOfCode2022
{
    public static class ResultsDisplayer
    {
        public static void DisplayFirstDayResults()
        {
            string[] input = Day1.CalorieCounting.GetInput();

            int res1 = Day1.CalorieCounting.GetFirstTaskResult(input);
            int res2 = Day1.CalorieCounting.GetSecondTaskResult(input);

            Helper.DisplayResultsOnConsole(1, res1, res2);
        }

        public static void DisplaySecondDayResults()
        {
            string[] input = Day2.Game.GetInput();

            int res1 = Day2.Game.GetFirstTaskResult(input);
            int res2 = Day2.Game.GetSecondTaskResult(input);

            Helper.DisplayResultsOnConsole(2, res1, res2);
        }

        public static void DisplayThirdDayResults()
        {
            string[] input = Day3.Solution3.GetInput();

            int res1 = Day3.Solution3.GetFirstTaskResult(input);
            int res2 = Day3.Solution3.GetSecondTaskResult(input);

            Helper.DisplayResultsOnConsole(2, res1, res2);
        }
    }
}
