using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class SelfCrossingTest {
    private readonly SelfCrossing _sc = new();

    public static IEnumerable<object[]> SelfCrossData {
        get {
            yield return new object[] { new[] { 2, 1, 1, 2 }, true };
            yield return new object[] { new[] { 1, 2, 3, 4 }, false };
            yield return new object[] { new[] { 1, 1, 1, 2, 1 }, true };
            yield return new object[] { new[] { 1, 1, 2, 2, 3, 3, 4, 4 }, false };
            yield return new object[] { new[] { 1, 1, 2, 2, 3, 3, 3, 4 }, true };

            yield return new object[] { Enumerable.Range(1, 100_000).ToArray(), false };
        }
    }

    [Theory]
    [MemberData(nameof(SelfCrossData))]
    public void Test(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossing(points);
        Assert.Equal(expected, actual);
    }
}