namespace Algorithms.xUnitTests._1_20
{
    public class _19_ReverseList
    {
        [Theory]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void Should_Be_Reversed_Correctly(int[] head, int[] expected)
        {
            // Action
            var output = Algorithms_1_20._19_ReverseList(head.ToListNode());

            // Assert
            output.ToArray().Should().Equal(expected);
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { 1 })]
        [InlineData(new int[] { 1 }, new int[] { 2 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 3, 4, 2, 1 })]
        public void Should_Be_Reversed_Incorrectly(int[] head, int[] expected)
        {
            // Action
            var output = Algorithms_1_20._19_ReverseList(head.ToListNode());

            // Assert
            output.ToArray().Should().NotEqual(expected);
        }
    }
}
