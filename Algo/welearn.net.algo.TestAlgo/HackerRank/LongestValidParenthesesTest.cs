using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank; 

public class LongestValidParenthesesTest {
    [Theory]
    [InlineData("", 0)]
    [InlineData("(()", 2)]
    [InlineData("()()", 4)]
    [InlineData("()(())", 6)]
    [InlineData(")()())", 4)]
    public void Test(string s, int expected) {
        var actual = LongestValidParentheses.Find2(s);
        Assert.Equal(expected, actual);
    }
}