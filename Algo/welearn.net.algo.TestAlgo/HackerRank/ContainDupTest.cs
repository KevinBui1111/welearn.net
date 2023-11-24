using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class ContainDupTest {
    public static IEnumerable<object[]> ContainDupData {
        get {
            yield return new object[] { new[] { -3, 3 }, 2, 4, false };
            yield return new object[] { new[] { -1, 2 }, 2, 3, true };
            yield return new object[] { new[] { 1, 2, 3, 1 }, 3, 0, true };
            yield return new object[] { new[] { 1, 5, 9, 1, 5, 9 }, 2, 3, false };
            
            var a = Enumerable.Range(1, 100_000).ToArray();
            a[^2] = 100_000;
            yield return new object[] { a, 100_000, 0, true };

            // 1,3,5,... 100k - 1
            a = Enumerable.Range(1, 50_000).Select(i => i * 2 - 1).Concat(
                // 2,4,5,... 99998k
                Enumerable.Range(1, 50_000 - 1).Select(i => i * 2)
            ).Concat(new [] { 100_000, 100_001}).ToArray();
            var indexes = Enumerable.Range(0, a.Length).ToArray();
            Array.Sort(a, indexes);
            yield return new object[] { indexes, 500_000, 1, true };
        }
    }
    
    [Theory]
    [MemberData(nameof(ContainDupData))]
    public void Test(int[] nums, int indexDiff, int valueDiff, bool expected) {
        var actual = new ContainsDuplicateIII().ContainsNearbyAlmostDuplicate(nums, indexDiff,valueDiff);
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [MemberData(nameof(ContainDupData))]
    public void Test2(int[] nums, int indexDiff, int valueDiff, bool expected) {
        var actual = new ContainsDuplicateIII().Contains2(nums, indexDiff,valueDiff);
        Assert.Equal(expected, actual);
    }
}