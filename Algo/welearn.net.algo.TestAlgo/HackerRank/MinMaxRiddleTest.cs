using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class MinMaxRiddleTest {
    [Theory]
    [InlineData(new long[] { 2, 6, 1, 12 }, new long[] { 12, 2, 1, 1 })]
    [InlineData(new long[] { 1, 2, 3, 5, 1, 13, 3 }, new long[] { 13, 3, 2, 1, 1, 1, 1 })]
    [InlineData(new long[] { 3, 5, 4, 7, 6, 2 }, new long[] { 7, 6, 4, 4, 3, 2 })]
    [InlineData(
        new long[] {
            789168277, 694294362, 532144299, 20472621, 316665904, 59654039, 685958445, 925819184, 371690486, 285650353,
            522515445, 624800694, 396417773, 467681822, 964079876, 355847868, 424895284, 50621903, 728094833, 535436067,
            221600465, 832169804, 641711594, 518285605, 235027997, 904664230, 223080251, 337085579, 5125280, 448775176,
            831453463, 550142629, 822686012, 555190916, 911857735, 144603739, 751265137, 274554418, 450666269,
            984349810, 716998518, 949717950, 313190920, 600769443, 140712186, 218387168, 416515873, 194487510,
            149671312, 241556542, 575727819, 873823206
        },
        new long[] {
            984349810, 716998518, 716998518, 550142629, 550142629, 448775176, 355847868, 285650353, 285650353,
            285650353, 285650353, 144603739, 144603739, 144603739, 144603739, 140712186, 140712186, 140712186,
            140712186, 140712186, 140712186, 140712186, 140712186, 50621903, 20472621, 20472621, 20472621, 20472621,
            5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280,
            5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280, 5125280
        })]
    public void Test(long[] arr, long[] expected) {
        var actual = MinMaxRiddle.Riddle(arr);
        var actual2 = MinMaxRiddle.riddle_naive(arr);
        var actual1 = MinMaxRiddle.riddle_better(arr);
        Assert.Equal(expected, actual);
        Assert.Equal(expected, actual1);
        Assert.Equal(expected, actual2);
    }
}