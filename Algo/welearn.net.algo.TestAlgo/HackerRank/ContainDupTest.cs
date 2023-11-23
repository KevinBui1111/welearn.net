using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class ContainDupTest {
    public static IEnumerable<object[]> ContainDupData {
        get {
            var a = Enumerable.Range(1, 100_000).ToArray();
            a[^2] = 100_000;
            yield return new object[] { a, 100_000, 0, true };
        }
    }
    [Theory]
    [InlineData(new []{1,2,3,1},3,0,true)]
    [InlineData(new []{1,5,9,1,5,9},2,3,false)]
    [MemberData(nameof(ContainDupData))]
    public void Test(int[] nums, int indexDiff, int valueDiff, bool expected) {
        var actual = new ContainsDuplicateIII().ContainsNearbyAlmostDuplicate(nums, indexDiff,valueDiff);
        Assert.Equal(expected, actual);
    }
}