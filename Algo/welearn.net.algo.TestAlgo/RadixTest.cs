using welearn.net.algo.piece;

namespace welearn.net.algo.TestAlgo;

public class RadixTest {
    private static readonly int[] TestArray = {
        0, 1, 2, 3, 4, 10, 11, 16, 32, 63, 64, 99, 100, 127, 128, 256, 512, 513, 1024, 1111, 2048,
        2804, 4095, 4096, 1_000_000, 19881_111, 19_920_428, 1988_11_11, 1992_04_28, 2023_02_08, 
        1_000_000_000, int.MaxValue
    };

    public static IEnumerable<object[]> ToBinaryTestData =>
        TestArray.Select(n =>
            new object[] { n, 2, Convert.ToString(n, 2) }
        );

    public static IEnumerable<object[]> To16TestData =>
        TestArray.Select(n =>
            new object[] { n, 16, Convert.ToString(n, 16).ToUpper() }
        );

    [Theory]
    [MemberData(nameof(ToBinaryTestData))]
    [MemberData(nameof(To16TestData))]
    public void ToRadix(int number, int radix, string expected) {
        var actual = Radix.ToRadix(number, radix);
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> Bytes16TestData =>
        TestArray.Select(n =>
            new object[] { BitConverter.GetBytes(n), 16, Convert.ToString(n, 16).ToUpper() }
        );
    
    [Theory]
    [MemberData(nameof(Bytes16TestData))]
    public void ToRadixByte(byte[] bytes, int radix, string expected) {
        var actual = Radix.ToRadix(bytes, radix);
        Assert.Equal(expected, actual);
    }
}