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

    public static int[] ToIntArray(byte[] bytes) {
        // trim zero byte
        var length = bytes.Length;
        while (length > 0 && bytes[length - 1] == 0) {
            --length;
        }

        var integer = 0;
        var intArray = new int[length / 4 + ((length & 3) == 0 ? 0 : 1)];

        for (var i = 0; i < length; ++i) {
            integer = bytes[i] << (8 * i) | integer;
            if ((i & 3) != 3) continue;
            // group 4
            intArray[i / 4] = integer;
            integer = 0;
        }

        if (integer > 0) intArray[length / 4] = integer;

        return intArray;
    }

    public static string ToDecimal(byte[] bytes) {
        var ints = ToIntArray(bytes).Reverse();
        const uint limitUnit = 1_000_000_000;
        var intBuffer = new List<ulong>();

        foreach (var t in ints) {
            PushNewInt(intBuffer, t);
        }

        if (intBuffer.Count == 0) return "0";

        var sb = new StringBuilder(intBuffer[^1].ToString());
        for (var i = intBuffer.Count - 2; i >= 0; --i) {
            sb.Append($"{intBuffer[i]:D9}");
        }

        return sb.ToString();

        void PushNewInt(IList<ulong> buffer, int newInt) {
            var added = (ulong)(uint)newInt;
            for (var i = 0; i < buffer.Count; ++i) {
                var upValue = buffer[i] << 32 | added;
                buffer[i] = upValue % limitUnit;
                added = upValue / limitUnit;
            }

            if (added == 0) return;

            buffer.Add(added % limitUnit);
            added /= limitUnit;
            if (added > 0) buffer.Add(added);
        }
    }

    public static void Main() {
        var hex = Convert.FromHexString("5DB4CEE3BFD8436395D37FCA2D48D5B3");
        Array.Reverse(hex);
        Console.WriteLine(ToRadix(hex, 36));
        Console.WriteLine(ToRadix(hex, 62));
        // var bytes = Encoding.UTF8.GetBytes("%-=i*[");
        var bytes = hex;
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
        Console.WriteLine(b);

        bytes = BitConverter.GetBytes((long)b);
        Console.WriteLine(BitConverter.ToString(bytes));
    }
}