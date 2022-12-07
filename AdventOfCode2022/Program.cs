using System;

namespace AdventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

        }

        static void DaySixResults()
        {
            string input = Day6.DaySixTask.GetDay6Input();

            Console.WriteLine($"Day 6: Result of the first task = {Day6.DaySixTask.RunDay6TaskFirstPart(input)}");
            Console.WriteLine($"Day 6: Result of the second task = {Day6.DaySixTask.RunDay6TaskSecondPart(input)}");

        }

        //Refactor
        static void DayFiveResults()
        {
            var instructions = Day5.DataParser.GetInstructions();
            var structureInput = Day5.DataParser.GetStructureInput();
            var structureList = Day5.DataParser.ParseInputReturnListOfStacks(structureInput);

            foreach (var row in instructions)
            {
                int[] instructionsArr = Day5.DataParser.ParseInstructions(row);
                Day5.CargoMover.MoveItemByInstructionSecond(instructionsArr[0], instructionsArr[1] - 1, instructionsArr[2] - 1, structureList);
            }

            foreach (var stack in structureList)
            {
                Console.Write(stack?.Peek());
            }
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
