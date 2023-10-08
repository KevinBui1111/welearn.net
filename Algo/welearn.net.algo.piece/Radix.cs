using System.Numerics;
using System.Text;

namespace welearn.net.algo.piece;

public class Radix {
    public static string ToBinaryLinQ(int number) =>
        Enumerable
            .Range(0, (int)Math.Log(number, 2) + 1)
            .Aggregate(string.Empty,
                (collected, bitshifts) => ((number >> bitshifts) & 1) + collected
            );

    private static readonly string RadixDigit = new string(
        new[] {
                Enumerable.Range('0', 10).Select(i => (char)i),
                Enumerable.Range('A', 26).Select(i => (char)i),
                Enumerable.Range('a', 26).Select(i => (char)i)
            }
            .SelectMany(x => x)
            .ToArray()
    );

    public static string ToRadix(int number, int radix) {
        var result = new StringBuilder();
        var quotient = number;
        while (quotient > 0) {
            var remainder = quotient % radix;
            quotient /= radix;
            result.Insert(0, RadixDigit[remainder]);
        }

        return result.Length == 0 ? "0" : result.ToString();
    }

    public static string ToRadix(byte[] bytes, int radix) {
        var result = new StringBuilder();
        var quotient = new BigInteger(bytes, true);
        while (quotient > 0) {
            var remainder = quotient % radix;
            quotient /= radix;
            result.Insert(0, RadixDigit[(int)remainder]);
        }

        return result.Length == 0 ? "0" : result.ToString();
    }

    public static void Main() {
        var hex = Convert.FromHexString("5DB4CEE3BFD8436395D37FCA2D48D5B3");
        Array.Reverse(hex);
        Console.WriteLine(ToRadix(hex, 36));
        Console.WriteLine(ToRadix(hex, 62));
        var bytes = Encoding.UTF8.GetBytes("%-=i*[");
        Console.WriteLine(Convert.ToHexString(bytes));
        // bytes = new byte[] { 1, 2, 64 };
        Console.WriteLine(BitConverter.ToString(bytes));
        var result = string.Concat(
            bytes.Select(b =>
                Convert.ToString(b, 2)
                    .PadLeft(8, '0')
            ).Reverse()
        );
        Console.WriteLine(result);

        var b = new BigInteger(bytes);
        Console.WriteLine(b.ToString());

        bytes = BitConverter.GetBytes((long)b);
        Console.WriteLine(BitConverter.ToString(bytes));
        
    }
}