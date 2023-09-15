using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class DivisibleSumPairsTest {
    [Theory]
    [InlineData(3, new[] { 1, 3, 2, 6, 1, 2 }, 5)]
    public void Test(int k, int[] ar, int expected) {
        var actual = DivisibleSumPairs.HowMany(k, ar);
        Assert.Equal(expected, actual);
    }
}