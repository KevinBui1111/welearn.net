using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class NextGreaterElementTest {
    [Theory]
    [InlineData(new[] { 1, 3, 2, 4 },
        new[] { 3, 4, 4, -1 }
    )]
    [InlineData(new[] { 6, 8, 0, 1, 3 },
        new[] { 8, -1, 1, 3, -1 }
    )]
    [InlineData(new[] { 1, 30, 25, 20, 5, 6, 7, 14, 10, 9, 7, 13 },
        new[] { 30, -1, -1, -1, 6, 7, 14, -1, 13, 13, 13, -1 }
    )]
    public void Test(int[] list, int[] expected) {
        var actual = NextGreaterElement.next_greater_element(list);
        Assert.Equal(expected, actual);
    }
}