using System.Numerics;
using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank; 

public class MultiplyStringsTest {
    
    [Theory]
    [InlineData("12345678", "98765432")]
    [InlineData("12345678", "198765432")]
    [InlineData("0000008", "198765432")]
    [InlineData("0", "0")]
    public void Test(string num1, string num2) {
        var actual = MultiplyStrings.Multiply(num1, num2);

        var bi1 = BigInteger.Parse(num1);
        var bi2 = BigInteger.Parse(num2);
        var expected = bi1 * bi2;
        Assert.Equal(expected.ToString(), actual);
    }
}