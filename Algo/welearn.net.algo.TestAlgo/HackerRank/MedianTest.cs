using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class MedianTest {
    [Theory]
    [InlineData(
        new[] { 1, 2, 3 },
        new[] { 2, 2, 3 },
        new[] { 1, 2, 2, 2, 3, 3 }
    )]
    [InlineData(
        new[] { 1, 2, 3 },
        new[] { 4, 5, 6, 7 },
        new[] { 1, 2, 3, 4, 5, 6, 7 }
    )]
    [InlineData(
        new[] { 1, 2, 5, 8 },
        new[] { 3, 6 },
        new[] { 1, 2, 3, 5, 6, 8 }
    )]
    public void MergeSortedArrays(int[] nums1, int[] nums2, int[] expected) {
        var actual = Median.MergeSortedArrays(nums1, nums2);
        Assert.Equal(expected, actual);
    }
}