using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class StockMaximizeTest {
    [Theory]
    [InlineData(new[] { 5, 3, 2 }, 0)]
    [InlineData(new[] { 1, 2, 100 }, 197)]
    [InlineData(new[] { 1, 3, 1, 2 }, 3)]
    public void Test(int[] prices, int expected) {
        var actual = StockMaximize.StockMax_(prices.ToList());
        var actual2 = StockMaximize.StockMax(prices.ToList());
        Assert.Equal(expected, actual);
        Assert.Equal(expected, actual2);
    }
}