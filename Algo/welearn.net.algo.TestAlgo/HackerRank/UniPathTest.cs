using System.Numerics;
using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class UniPathTest {
    [Theory]
    [InlineData(3, 7, 28)]
    [InlineData(4, 7, 84)]
    [InlineData(4, 6, 56)]
    public void Test(int m, int n, int expected) {
        var actual = UniquePaths.HowManyPath(m, n);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> Path3Data =>
        new List<object[]> {
            new object[] {
                new[] {
                    new[] { 1, 0, 0, 0 },
                    new[] { 0, 0, 0, 0 },
                    new[] { 0, 0, 2, -1 }
                },
                2
            },
            new object[] {
                new[] {
                    new[] { 1, 0, 0, 0 },
                    new[] { 0, 0, 0, 0 },
                    new[] { 0, 0, 0, 2 }
                },
                4
            },
            new object[] {
                new[] {
                    new[] { 0,1 },
                    new[] { 2,0 },
                },
                0
            }
        };

    [Theory]
    [MemberData(nameof(Path3Data))]
    public void HowManyPath3(int[][] grid, int expected) {
        var actual = UniquePaths.HowManyPathIII(grid);

        Assert.Equal(expected, actual);
    }
}