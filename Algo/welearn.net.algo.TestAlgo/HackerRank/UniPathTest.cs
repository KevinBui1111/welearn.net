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
}