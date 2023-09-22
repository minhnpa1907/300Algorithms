namespace Algorithms.UnitTests._1_20
{
    public class _1_TwoSum
    {
        [SetUp]
        public void Setup()
        { }

        [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [TestCase(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [TestCase(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        [TestCase(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new[] { 5, 11 })]
        public void TwoSum_EqualTest(int[] nums, int target, int[] result)
        {
            // Act
            var output = Algorithms_1_20._1_TwoSum(nums, target);

            // Assert
            Assert.That(output, Is.EqualTo(result));
        }

        [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
        [TestCase(new[] { 3, 2, 4 }, 6, new[] { 1, 3 })]
        [TestCase(new[] { 3, 3 }, 6, new[] { 0, 0 })]
        [TestCase(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new[] { 4, 11 })]
        public void TwoSum_NotEqualTest(int[] nums, int target, int[] result)
        {
            // Act
            var output = Algorithms_1_20._1_TwoSum(nums, target);

            // Assert
            Assert.That(output, !Is.EqualTo(result));
        }
    }
}
