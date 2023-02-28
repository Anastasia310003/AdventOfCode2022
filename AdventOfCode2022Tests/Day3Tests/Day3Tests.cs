using NUnit.Framework;
using AdventOfCode2022;
using AdventOfCode2022.Day3;
using System.IO;

namespace AdventOfCode2022Tests.Day3Tests
{
    [TestFixture]
    internal class Day3Tests
    {
        private string[] inputLines;

        [OneTimeSetUp]
        public void Setup()
        {
            inputLines = System.IO.File.ReadAllLines(
            Path.Combine(Helper.GetBaseDirectory(), @"AdventOfCode2022\AdventOfCode2022Tests\Day3Tests\Day3TestInput.txt")
            );
        }

        [Test]
        public void GetFirstTaskResult_ReturnsSum()
        {
            int totalExpectedSum = 157;

            int resultScore = Solution3.GetFirstTaskResult(inputLines);

            Assert.AreEqual(totalExpectedSum, resultScore);
        }

        [Test]
        public void GetSecondTaskResult_ReturnsSum()
        {
            int totalExpectedSum = 70;

            int resultScore = Solution3.GetSecondTaskResult(inputLines);

            Assert.AreEqual(totalExpectedSum, resultScore);
        }

    }
}
