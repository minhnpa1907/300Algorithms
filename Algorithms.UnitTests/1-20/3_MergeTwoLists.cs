// Author: minhnpa1907@gmail.com
using NPAM.Algorithms.Extensions;
using NPAM.Algorithms.Models;

namespace NPAM.Algorithms.UnitTests._1_20;

public class _3_MergeTwoLists
{
    [SetUp]
    public void Setup()
    { }

    [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
    [TestCase(new int[] { }, new int[] { }, new int[] { })]
    [TestCase(new int[] { }, new int[] { 0 }, new int[] { 0 })]
    [TestCase(new int[] { 1, 2, 4 }, new int[] { }, new int[] { 1, 2, 4 })]
    public void MergeTwoLists_EqualTest(int[] nums1, int[] nums2, int[] result)
    {
        // Act
        var output = Probl1ToProbl20._3_MergeTwoLists(nums1.ToListNode(), nums2.ToListNode());

        // Assert
        Assert.That(output.ToArray(), Is.EqualTo(result));
    }

    [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 2, 4, 1, 3, 4 })]
    [TestCase(new int[] { }, new int[] { }, new int[] { 0 })]
    [TestCase(new int[] { }, new int[] { 0 }, new int[] { })]
    [TestCase(new int[] { 1, 2, 4 }, new int[] { }, new int[] { 0, 1, 2, 4 })]
    public void MergeTwoLists_NotEqualTest(int[] nums1, int[] nums2, int[] result)
    {
        // Act
        var output = Probl1ToProbl20._3_MergeTwoLists(nums1.ToListNode(), nums2.ToListNode());

        // Assert
        Assert.That(output.ToArray(), !Is.EqualTo(result));
    }
}
