using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class SelfCrossingTest {
    private readonly SelfCrossing _sc = new();
    private readonly SelfCrossing2 _sc2 = new();

    public static IEnumerable<object[]> SelfCrossData {
        get {
            yield return new object[] { new[] { 1, 1, 3 }, false };
            yield return new object[] { new[] { 1, 1, 3, 2, 1, 1 }, false };
            yield return new object[] { new[] { 1, 2, 2, 2 }, false };
            yield return new object[] { new[] { 1, 1, 2, 1, 1 }, true };
            yield return new object[] { new[] { 2, 1, 1, 2 }, true };
            yield return new object[] { new[] { 1, 2, 3, 4 }, false };
            yield return new object[] { new[] { 1, 1, 1, 2, 1 }, true };
            yield return new object[] { new[] { 1, 1, 2, 2, 3, 3, 4, 4 }, false };
            yield return new object[] { new[] { 1, 1, 2, 2, 3, 3, 3, 4 }, true };

            yield return new object[] { Enumerable.Range(1, 100_000).ToArray(), false };

            yield return new object[] { new[] { 1, 1, 2, 3, 7, 8, 4, 7, 3, 6, 2, 5, 2 }, true };
        }
    }

    [Theory(Skip = "Omit")]
    [MemberData(nameof(SelfCrossData))]
    public void Test(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossing(points);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(SelfCrossData))]
    public void Test2(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossing2(points);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(SelfCrossData))]
    public void Test3(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossingOther(points);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(SelfCrossData))]
    public void Test4(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossing4(points);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(SelfCrossData))]
    public void Test5(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossing5(points);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(SelfCrossData))]
    public void TestPython(int[] points, bool expected) {
        var actual = _sc.IsSelfCrossingPython(points);
        Assert.Equal(expected, actual);
    }
}