using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022.Day2
{
    public static class Game
    {
        private static readonly char rock1 = 'A', rock2 = 'X';
        private static readonly char paper1 = 'B', paper2 = 'Y';
        private static readonly char scissors1 = 'C', scissors2 = 'Z';
        private static readonly int draw = 0, firstWon = 1, secondWon = 2;
        private static readonly List<char> _allowedInputsFirst = new List<char>() { rock1 , paper1, scissors1};
        private static readonly List<char> _allowedInputsSecond = new List<char>() {rock2, paper2, scissors2};

        public static string[] GetInput()
        {
            return System.IO.File.ReadAllLines(
            Path.Combine(Helper.GetBaseDirectory(), @"AdventOfCode2022\AdventOfCode2022\Day2\Input.txt")
            );
        }

        public static int GetFirstTaskResult(string[] input)
        {
            int totalPoints = 0;

            foreach(string round in input)
            {
                if(input.Length < 3)
                    throw new ArgumentException($"Day2.Game.CalculateGamePointsForFirstPlayer -> Invalid argument(s) passed. String row: {round}.");

                int gameResult = CalculateWinner(round[0], round[2]);

                totalPoints += CalculateWinPoints(gameResult);
                totalPoints += CalculateChoicePoints(round[0]);
            }

            return totalPoints;
        }

        /// <summary>
        /// Calculates the winner on rock-paper-scissors game
        /// </summary>
        /// <param name="first">first player choice</param>
        /// <param name="second">second player choice</param>
        /// <returns>0 - if draw, 1 - first player wins, 2 - second player wins, -1 if something terible happens and one of the flows was not considered</returns>
        /// <exception cref="ArgumentException">throws Argument exeption if arguments are invalid</exception>
        public static int CalculateWinner(char first, char second)
        {
            if (!InputValid(first, second))
                throw new ArgumentException($"Day2.Game.CalculateWinner -> Invalid argument(s) passed. Values: {first}, {second}.");

            //Draw
            if (first == rock1 && second == rock2 || first == paper1 && second == paper2
                || first == scissors1 && second == scissors2)
                return draw;

            //First wins
            if (first == rock1 && second == scissors2 || first == paper1 && second == rock2
                || first == scissors1 && second == paper2)
                return firstWon;

            //Second wins
            if (first == rock1 && second == paper2 || first == paper1 && second == scissors2
                || first == scissors1 && second == rock2)
                return secondWon;

            return -1;
        }

        private static int CalculateChoicePoints(char first)
        {
            if (first == rock1)
                return 1;
            else if (first == paper1)
                return 2;
            else if (first == scissors1)
                return 3;
            else
                return 0;
        }

        private static int CalculateWinPoints(int gameResult)
        {
            if (gameResult == draw) return 3;

            else if (gameResult == firstWon) return 6;

            else return 0;
        }

        private static bool InputValid(char first, char second)
        {
            return _allowedInputsFirst.Contains(first) && _allowedInputsSecond.Contains(second);
        }
    }
}
