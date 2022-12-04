using AdventOfCode2022;
using NUnit.Framework;


namespace AdventOfCode2022Tests.Day4Tests
{
    public class DayFourTaskTests
    {
        [Test]
        public void OneRangeContainsAnother_FirstContainsSecond_ReturnTrue_Test()
        {
            int start1 = 3, end1 = 8, start2 = 4, end2 = 5;

            Assert.IsTrue(DayFourTask.OneRangeContainsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void OneRangeContainsAnother_FirstContainsSecond_IncludingEdges_ReturnTrue_Test()
        {
            int start1 = 3, end1 = 8, start2 = 3, end2 = 7;

            Assert.IsTrue(DayFourTask.OneRangeContainsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void OneRangeContainsAnother_SecondCOntainsFirst_ReturnTrue_Test()
        {
            int start1 = 2, end1 = 4, start2 = 1, end2 = 5;

            Assert.IsTrue(DayFourTask.OneRangeContainsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void OneRangeContainsAnother_SecondCOntainsFirst_IncludingEdges_ReturnTrue_Test()
        {
            int start1 = 2, end1 = 4, start2 = 1, end2 = 4;

            Assert.IsTrue(DayFourTask.OneRangeContainsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void OneRangeContainsAnother_RangesAreEqual_ReturnTrue_Test()
        {
            int start1 = 2, end1 = 4, start2 = 2, end2 = 4;

            Assert.IsTrue(DayFourTask.OneRangeContainsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void OneRangeContainsAnother_ReturnFalse_Test()
        {
            int start1 = 3, end1 = 8, start2 = 4, end2 = 9;

            Assert.IsFalse(DayFourTask.OneRangeContainsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void CountIfOneRangeContainAnother_FirstContainsSecond_Return1_Test()
        {
            string[] input = { "3-8,4-6" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeContainAnother(input), 1);
        }

        [Test]
        public void CountIfOneRangeContainAnother_SecondContainsFirst_Return1_Test()
        {
            string[] input = { "3-4,2-6" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeContainAnother(input), 1);
        }

        [Test]
        public void CountIfOneRangeContainAnother_Multiple_Return2_Test()
        {
            string[] input = { "3-8,4-6", "3-5,4-8", "5-5,4-16" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeContainAnother(input), 2);
        }

        [Test]
        public void OneRangeOverlapsAnother_ReturnTrue_Test()
        {
            int start1 = 3, end1 = 8, start2 = 8, end2 = 9;

            Assert.IsTrue(DayFourTask.OneRangeOverlapsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void OneRangeOverlapsAnother_ReturnFalse_Test()
        {
            int start1 = 3, end1 = 8, start2 = 9, end2 = 9;

            Assert.IsFalse(DayFourTask.OneRangeOverlapsAnother(start1, end1, start2, end2));
        }

        [Test]
        public void CountIfOneRangeOverlapsAnother_Return1_Test()
        {
            string[] input = { "3-4,2-6" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeOverlapsAnother(input), 1);
        }

        [Test]
        public void CountIfOneRangeOverlapsAnother_Return0_Test()
        {
            string[] input = { "3-4,5-6" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeOverlapsAnother(input), 0);
        }

        [Test]
        public void CountIfOneRangeOverlapsAnother_Multiple_Return2_Test()
        {
            string[] input = { "3-8,8-9", "3-5,4-8", "1-2,4-16" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeOverlapsAnother(input), 2);
        }

        [Test]
        public void CountIfOneRangeOverlapsAnother_Multiple_Return0_Test()
        {
            string[] input = { "3-8,9-9", "3-5,6-8", "1-2,4-16" };

            Assert.AreEqual(DayFourTask.CountIfOneRangeOverlapsAnother(input), 0);
        }
    }
}
