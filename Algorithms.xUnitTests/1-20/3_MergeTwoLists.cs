using NPAM.Algorithms.Extensions;

namespace NPAM.Algorithms.xUnitTests._1_20
{
    [Trait(Constants.TRAIT_CATEGORY, Constants.TRAIT_UNIT_TEST)]
    public class _3_MergeTwoLists
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        [InlineData(new int[] { }, new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { }, new int[] { 1, 2, 4 })]
        public void Should_Be_Merged_TwoLists_Correctlly(int[] nums1, int[] nums2, int[] result)
        {
            // Act
            var output = Probl1ToProbl20._3_MergeTwoLists(nums1.ToListNode(), nums2.ToListNode());

            // Assert
            output.ToArray().Should().Equal(result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 2, 4, 1, 3, 4 })]
        [InlineData(new int[] { }, new int[] { }, new int[] { 0 })]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { }, new int[] { 0, 1, 2, 4 })]
        public void Should_Be_Merged_TwoLists_Incorrectlly(int[] nums1, int[] nums2, int[] result)
        {
            // Act
            var output = Probl1ToProbl20._3_MergeTwoLists(nums1.ToListNode(), nums2.ToListNode());

            // Assert
            output.ToArray().Should().NotEqual(result);
        }
    }
}
