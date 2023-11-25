using welearn.net.algo.piece.LeetCode;

namespace welearn.net.algo.TestAlgo.LeetCode; 

public class ReducingDishesTest {
    [Theory]
    [InlineData(new [] {-1,-8,0,5,-9}, 14)]
    [InlineData(new [] {4,3,2}, 20)]
    [InlineData(new [] {-1,-4,-5}, 0)]
    public void Test(int[] satisfaction, int expected) {
        var actual = new ReducingDishes().MaxSatisfaction2(satisfaction);
        Assert.Equal(expected, actual);
    }
}