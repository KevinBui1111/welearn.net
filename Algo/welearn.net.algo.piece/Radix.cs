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

    public static void Main() {
    }
}