namespace Algorithms.xUnitTests._21_40
{
    public class _21_AddBinary
    {
        [Theory]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        [InlineData("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101", "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011", "110111101100010011000101110110100000011101000101011001000011011000001100011110011010010011000000000")]
        public void Should_Be_Converted_Correctly(string a, string b, string expected)
        {
            // Action
            var output = Algorithms_21_40._21_AddBinary(a, b);

            // Assert
            output.Should().Be(expected);
        }

        [Theory]
        [InlineData("11", "1", "101")]
        [InlineData("1010", "1011", "10001")]
        [InlineData("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101", "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011", "110111101100010010000101110110100000011101000101011001000011011000001100011110011010010011000000000")]
        public void Should_Be_Converted_Incorrectly(string a, string b, string expected)
        {
            // Action
            var output = Algorithms_21_40._21_AddBinary(a, b);

            // Assert
            output.Should().NotBe(expected);
        }
    }
}
