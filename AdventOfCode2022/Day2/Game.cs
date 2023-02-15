using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022.Day2
{
    public static class Game
    {
        private static readonly char _oppRock = 'A', _myRock = 'X';
        private static readonly char _oppPaper = 'B', _myPaper = 'Y';
        private static readonly char _oppScissors = 'C', _myScissors = 'Z';
        private static readonly int _draw = 0, _iWon = 1, _iLost = 2;
        private static readonly char _endDraw = 'Y', _endWin = 'Z', _endLose = 'X';
        private static readonly List<char> _allowedInputsOpponent = new List<char>() { _oppRock , _oppPaper, _oppScissors};
        private static readonly List<char> _allowedInputsMe = new List<char>() {_myRock, _myPaper, _myScissors};

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
                totalPoints += CalculateChoicePoints(round[2]);
            }

            return totalPoints;
        }

        public static int GetSecondTaskResult(string[] input)
        {
            int totalPoints = 0;

            foreach (string round in input)
            {
                if (input.Length < 3)
                    throw new ArgumentException($"Day2.Game.CalculateGamePointsForFirstPlayer -> Invalid argument(s) passed. String row: {round}.");

                char myChoice = FollowInstruction(round[2], round[0]);
                int gameResult = CalculateWinner(round[0], myChoice);

                totalPoints += CalculateWinPoints(gameResult);
                totalPoints += CalculateChoicePoints(myChoice);
            }

            return totalPoints;
        }

        /// <summary>
        /// Calculates the winner on rock-paper-scissors game
        /// </summary>
        /// <param name="opponentChoice">opponent choice</param>
        /// <param name="myChoice">my choice</param>
        /// <returns>0 - if draw, 1 - opponent wins, 2 - I win</returns>
        /// <exception cref="ArgumentException">throws Argument exeption if arguments are invalid</exception>
        /// <exception cref="Exception">throws Exeption if none of the valid flows work</exception>
        public static int CalculateWinner(char opponentChoice, char myChoice)
        {
            if (!InputValid(opponentChoice, myChoice))
                throw new ArgumentException($"Day2.Game.CalculateWinner -> Invalid argument(s) passed. Values: {opponentChoice}, {myChoice}.");

            //Draw
            if (opponentChoice == _oppRock && myChoice == _myRock || opponentChoice == _oppPaper && myChoice == _myPaper
                || opponentChoice == _oppScissors && myChoice == _myScissors)
                return _draw;

            //Opponent wins
            if (opponentChoice == _oppRock && myChoice == _myScissors || opponentChoice == _oppPaper && myChoice == _myRock
                || opponentChoice == _oppScissors && myChoice == _myPaper)
                return _iLost;

            //I win
            if (opponentChoice == _oppRock && myChoice == _myPaper || opponentChoice == _oppPaper && myChoice == _myScissors
                || opponentChoice == _oppScissors && myChoice == _myRock)
                return _iWon;

            throw new Exception($"Day2.Game.CalculateWinner -> The flow was broken. Argument values:{opponentChoice}, {myChoice}.");
        }

        private static int CalculateChoicePoints(char myChoice)
        {
            if (myChoice == _myRock)
                return 1;
            else if (myChoice == _myPaper)
                return 2;
            else if (myChoice == _myScissors)
                return 3;
            else
                throw new ArgumentException($"Day2.Game.CalculateChoicePoints -> Invalid argument(s) passed. Values: {myChoice}.");
        }

        private static int CalculateWinPoints(int gameResult)
        {
            if (gameResult == _draw) return 3;

            else if (gameResult == _iWon) return 6;

            else if (gameResult == _iLost) return 0;

            else
                throw new Exception($"Day2.Game.CalculateWinPoints -> The flow was broken. Game result value:{gameResult}.");
        }

        private static bool InputValid(char opponentChoice, char myChoice)
        {
            return _allowedInputsOpponent.Contains(opponentChoice) && _allowedInputsMe.Contains(myChoice);
        }

        /// <summary>
        /// Gets my choice in order to follow the instruction and based on opponent choice.
        /// </summary>
        /// <param name="insctruction">X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.</param>
        /// <param name="opponentChoice">Opponent choice</param>
        /// <returns>My choice</returns>
        /// <exception cref="Exception">Throws exception if the flow is broken</exception>
        private static char FollowInstruction(char insctruction, char opponentChoice)
        {
            if(insctruction == _endDraw)
            {
                return GetDrawResult(opponentChoice);
            }

            if (insctruction == _endWin)
            {
                return GetWinResult(opponentChoice);
            }

            if (insctruction == _endLose)
            {
                return GetLoseResult(opponentChoice);
            }

            throw new Exception($"Day2.Game.FollowInstruction -> The flow was broken. Instruction:{insctruction}, opponent choice: {opponentChoice}");
        }

        private static char GetWinResult(char opponentChoice)
        {
            if (opponentChoice == _oppRock)
                return _myPaper;

            if (opponentChoice == _oppPaper)
                return _myScissors;

            if (opponentChoice == _oppScissors)
                return _myRock;

            throw new Exception($"Day2.Game.GetDrawResult -> The flow was broken. Opponent choice value:{opponentChoice}.");
        }

        private static char GetDrawResult(char opponentChoice)
        {
            if (opponentChoice == _oppRock)
                return _myRock;

            if (opponentChoice == _oppPaper)
                return _myPaper;

            if (opponentChoice == _oppScissors)
                return _myScissors;

            throw new Exception($"Day2.Game.GetDrawResult -> The flow was broken. Opponent choice value:{opponentChoice}.");
        }

        private static char GetLoseResult(char opponentChoice)
        {
            if (opponentChoice == _oppRock)
                return _myScissors;

            if (opponentChoice == _oppPaper)
                return _myRock;

            if (opponentChoice == _oppScissors)
                return _myPaper;

            throw new Exception($"Day2.Game.GetDrawResult -> The flow was broken. Opponent choice value:{opponentChoice}.");
        }
    }
}
