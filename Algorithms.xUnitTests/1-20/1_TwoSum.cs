namespace NPAM.Algorithms.xUnitTests._1_20
{
    [Trait(Constants.TRAIT_CATEGORY, Constants.TRAIT_UNIT_TEST)]
    public class _1_TwoSum
    {
        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        [InlineData(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new[] { 5, 11 })]
        public void Should_Be_Found_TwoSum_Correctly(int[] nums, int target, int[] result)
        {
            // Act
            var output = Probl1ToProbl20._1_TwoSum(nums, target);

            // Assert
            output.Should().Equal(result);
        }

        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 3 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 0 })]
        [InlineData(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new[] { 4, 11 })]
        public void Should_Be_Found_TwoSum_Incorrectly(int[] nums, int target, int[] result)
        {
            // Act
            var output = Probl1ToProbl20._1_TwoSum(nums, target);

            // Assert
            output.Should().NotEqual(result);
        }
    }
}
