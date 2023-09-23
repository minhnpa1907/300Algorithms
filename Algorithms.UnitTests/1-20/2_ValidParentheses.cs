// Author: minhnpa1907
namespace Algorithms.UnitTests._1_20
{
    public class _2_ValidParentheses
    {
        [SetUp]
        public void Setup()
        { }

        [TestCase("()", true)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        [TestCase("(((({{{[[[([{[[()]]}])]]]}}}))))", true)]
        [TestCase("(((({{[{[[()]]}])]]]}}}))))", false)]
        [TestCase("((", false)]
        public void ValidParentheses_EqualTest(string input, bool result)
        {
            // Act
            var output = Algorithms_1_20._2_ValidParentheses(input);

            // Assert
            Assert.That(output, Is.EqualTo(result));
        }

        [TestCase("()", false)]
        [TestCase("()[]{}", false)]
        [TestCase("(]", true)]
        [TestCase("(((({{{[[[([{[[()]]}])]]]}}}))))", false)]
        [TestCase("((", true)]
        public void ValidParentheses_NotEqualTest(string input, bool result)
        {
            // Act
            var output = Algorithms_1_20._2_ValidParentheses(input);

            // Assert
            Assert.That(output, !Is.EqualTo(result));
        }
    }
}
