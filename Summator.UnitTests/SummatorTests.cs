using NUnit.Framework;

namespace Summator.UnitTests
{
    public class SummatorTests
    {
        
        [Test]
        public void Test_Summator_SumTwoPositiveNumber()
        {
            var nums = new int[] { 1, 2, };
            var actual = Summator.Sum(nums);

            var expected = 3;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_SumTwoNegativeNumber()
        {
            var nums = new int[] { -1,-99 };
            var actual = Summator.Sum(nums);

            var expected = -100;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_OneNumber()
        {
            var nums = new int[] { 5 };
            var actual = Summator.Sum(nums);

            var expected = 5;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_NoNumbers()
        {
            var nums = new int[] { };
            var actual = Summator.Sum(nums);

            var expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_BigNumbers()
        {
            var nums = new int[] { 2000000000, 2000000000, 2000000000 };
            var actual = Summator.Sum(nums);

            var expected = 6000000000;

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void Test_Summator_AverageOfPositiveNumbers()
        {
            var nums = new int[] { 3, 8, 16 };
            var actual = Summator.Average(nums);

            var expected = (3 + 8 + 16) / nums.Length;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_AverageOfNegativeNumbers()
        {
            var nums = new int[] { -3, -8, -19 };
            var actual = Summator.Average(nums);

            var expected = -(3 + 8 + 19) / nums.Length;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_AverageOfDifferentNumbers()
        {
            var nums = new int[] { 3, -8, 19 };
            var actual = Summator.Average(nums);

            var expected = (double)(3 - 8 + 19) / nums.Length;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Summator_AverageOfOneNumber()
        {
            var nums = new int[] { 5 };
            var actual = Summator.Average(nums);

            var expected = 5;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}