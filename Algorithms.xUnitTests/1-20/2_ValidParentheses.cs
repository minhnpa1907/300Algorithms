namespace NPAM.Algorithms.xUnitTests._1_20
{
    [Trait(Constants.TRAIT_CATEGORY, Constants.TRAIT_UNIT_TEST)]
    public class _2_ValidParentheses
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("(((({{{[[[([{[[()]]}])]]]}}}))))", true)]
        [InlineData("(((({{[{[[()]]}])]]]}}}))))", false)]
        [InlineData("((", false)]
        public void Should_Be_Valid_Parentheses(string input, bool result)
        {
            // Act
            var output = Probl1ToProbl20._2_ValidParentheses(input);

            // Assert
            output.Should().Be(result);
        }

        [Theory]
        [InlineData("()", false)]
        [InlineData("()[]{}", false)]
        [InlineData("(]", true)]
        [InlineData("(((({{{[[[([{[[()]]}])]]]}}}))))", false)]
        [InlineData("((", true)]
        public void Should_Be_Invalid_Parentheses(string input, bool result)
        {
            // Act
            var output = Probl1ToProbl20._2_ValidParentheses(input);

            // Assert
            output.Should().NotBe(result);
        }
    }
}
