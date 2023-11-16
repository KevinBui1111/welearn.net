using System.Numerics;
using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class PrisonCellsAfterNDaysTest {
    [Theory]
    [InlineData(new[] { 0, 1, 0, 1, 1, 0, 0, 1 }, 1, new[] { 0, 1, 1, 0, 0, 0, 0, 0 })]
    [InlineData(new[] { 0, 1, 0, 1, 1, 0, 0, 1 }, 7, new[] { 0, 0, 1, 1, 0, 0, 0, 0 })]
    [InlineData(new[] { 1, 0, 0, 1, 0, 0, 1, 0 }, 1000000000, new[] { 0, 0, 1, 1, 1, 1, 1, 0 })]
    public void Test(int[] m, int n, int[] expected) {
        var actual = PrisonCellsAfterNDays.PrisonAfterNDays2(m, n);

        Assert.Equal(expected, actual);
    }
}