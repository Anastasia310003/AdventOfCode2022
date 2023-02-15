using AdventOfCode2022;
using AdventOfCode2022.Day2;
using NUnit.Framework;
using System;
using System.IO;

namespace AdventOfCode2022Tests.Day2Tests
{
    [TestFixture]
    internal class Day2Tests
    {
        private string[] inputLines;

        [OneTimeSetUp]
        public void Setup()
        {
            inputLines = System.IO.File.ReadAllLines(
            Path.Combine(Helper.GetBaseDirectory(), @"AdventOfCode2022\AdventOfCode2022Tests\Day2Tests\Day2TestInput.txt")
            );
        }

        [Test]
        [TestCase('A', 'G')]
        [TestCase('T', 'Y')]
        [TestCase('K', 'M')]
        public void CalculateWinner_ReturnsArgumentException(char opponentChoice, char myChoice)
        {
            Assert.Throws<ArgumentException>(() => { Game.CalculateWinner(opponentChoice, myChoice); });
        }

        [Test]
        [TestCase('A', 'X')]
        [TestCase('B', 'Y')]
        [TestCase('C', 'Z')]
        public void CalculateWinner_ReturnsDraw(char opponentChoice, char myChoice)
        {
            int gameRes = Game.CalculateWinner(opponentChoice, myChoice);

            Assert.AreEqual(gameRes, 0);
        }

        [Test]
        [TestCase('A', 'Z')]
        [TestCase('B', 'X')]
        [TestCase('C', 'Y')]
        public void CalculateWinner_ReturnsOpponentWin(char opponentChoice, char myChoice)
        {
            int gameRes = Game.CalculateWinner(opponentChoice, myChoice);

            Assert.AreEqual(gameRes, 2);
        }

        [Test]
        [TestCase('A', 'Y')]
        [TestCase('B', 'Z')]
        [TestCase('C', 'X')]
        public void CalculateWinner_ReturnsIWin(char opponentChoice, char myChoice)
        {
            int gameRes = Game.CalculateWinner(opponentChoice, myChoice);

            Assert.AreEqual(gameRes, 1);
        }

        [Test]
        public void GetFirstTaskResult_ReturnsMyTotalScore()
        {
            int totalExpectedScore = 15;

            int resultScore = Game.GetFirstTaskResult(inputLines);

            Assert.AreEqual(totalExpectedScore, resultScore);
        }

        [Test]
        public void GetSecondTaskResult_ReturnsMyTotalScore()
        {
            int totalExpectedScore = 12;

            int resultScore = Game.GetSecondTaskResult(inputLines);

            Assert.AreEqual(totalExpectedScore, resultScore);
        }
    }
}
