using AdventOfCode2022;
using AdventOfCode2022.Day1;
using NUnit.Framework;
using System.IO;

namespace AdventOfCode2022Tests.Day1Tests
{
    [TestFixture]
    public class Day1Tests
    {
        private string[] inputLines;

        [OneTimeSetUp]
        public void Setup()
        {
            inputLines = System.IO.File.ReadAllLines(
            Path.Combine(Helper.GetBaseDirectory(), @"AdventOfCode2022\AdventOfCode2022Tests\Day1Tests\Day1TestInput.txt")
            );
        }

        [Test]
        public void GetFirstTaskResult_ReturnsMaxTotalCalories()
        {
            int max = CalorieCounting.GetFirstTaskResult(inputLines);

            Assert.AreEqual(24000, max);
        }

        [Test]
        public void GetSecondTaskResult_ReturnsSumOfThreeMaxTotalCalories()
        {
            int topThree = CalorieCounting.GetSecondTaskResult(inputLines);

            Assert.AreEqual(45000, topThree);
        }
    }
}
