using System.Runtime.InteropServices;
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

    public static IEnumerable<object[]> TestByteArray => new List<object[]> {
        new object[] { new byte[] { 0x1, 0x2, 0x3, 0x4, 0x10, 0x11, 0x16, 0x32 }, new[] { 0x04030201, 0x32161110 } },
        new object[]
            { new byte[] { 0x63, 0x64, 0x99, 0x10, 0xE7, 0x4A, 0xFF, 0xC2 }, new[] { 0x10996463, -1023456537 } },
        new object[] { new byte[] { 0x1, 0x2, 0x3, 0x4, 0x10, 0x11 }, new[] { 0x04030201, 0x1110 } },
        new object[] { new byte[] { 0x00, 0x2, 0x3, 0x0, 0x10, 0x00 }, new[] { 0x030200, 0x10 } },
        new object[] { new byte[] { 0xAA, 0x0, 0x00, 0x0, 0x00, 0x00 }, new[] { 0xAA } },
        new object[] { new byte[] { 0x00, 0x0, 0x00, 0x0, 0x00, 0x00 }, Array.Empty<int>() },
        new object[] {
            Convert.FromHexString("B3D5482DCA7FD3956343D8BFE3CEB45D"),
            new[] { 0x2D48D5B3, -1781301302, -1076346013, 0x5DB4CEE3 }
        },
        new object[] {
            Convert.FromHexString("B3D5482DCA7FD3956343D8BFE3CEB4"),
            new[] { 0x2D48D5B3, -1781301302, -1076346013, 0xB4CEE3 }
        }
    };

    [Theory]
    [MemberData(nameof(TestByteArray))]
    public void ToIntArray(byte[] bytes, int[] expected) {
        var actual = Radix.ToIntArray(bytes);
        // var integerArray = MemoryMarshal.Cast<byte, int>(bytes.AsSpan());
        // var expected = integerArray.ToArray();
        Assert.Equal(expected, actual);
    }
}