namespace NPAM.Algorithms.xUnitTests._1_20;

[Trait(Constants.TRAIT_CATEGORY, Constants.TRAIT_UNIT_TEST)]
public class _20_MajorityElement
{
    [Theory]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1, 2, 2 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 2, 2 }, 2)]
    [InlineData(new int[] { -1, 1, 1, 1, 2 }, 1)]
    public void Should_Be_Found_Correctly(int[] nums, int expected)
    {
        // Action
        var output = Probl1ToProbl20._20_MajorityElement(nums);

        // Assert
        output.Should().Be(expected);
    }

    [Theory]
    [InlineData(new int[] { 1 }, 2)]
    [InlineData(new int[] { 1, 2, 2 }, 1)]
    [InlineData(new int[] { 1, 2, 3, 2, 2 }, 1)]
    [InlineData(new int[] { -1, 1, 1, 1, 2 }, 2)]
    public void Should_Be_Found_Incorrectly(int[] nums, int expected)
    {
        // Action
        var output = Probl1ToProbl20._20_MajorityElement(nums);

        // Assert
        output.Should().NotBe(expected);
    }
}
