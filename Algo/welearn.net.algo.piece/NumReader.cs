using System.Text;

namespace welearn.net.algo.piece;

internal static class NumReader {
    private static readonly string[] strDigit = [
        "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín "
    ];

    private static readonly string[] strGroup = ["nghìn ", "triệu ", "tỷ "];

    public static string Read(string iNum) {
        var k = 0;
        var s = "";
        if (string.IsNullOrEmpty(iNum)) return strDigit[0].Trim();
        iNum = iNum.Trim().TrimStart('0');
        if (string.IsNullOrEmpty(iNum)) return strDigit[0].Trim();

        int iG;
        string st;
        for (var i = iNum.Length - 6; i >= iNum.Length % 3; i -= 3) {
            iG = int.Parse(iNum.Substring(i, 3));
            st = Group3(iG);
            if (st != "")
                st += strGroup[k];
            else if (k % 3 == 2) st = strGroup[k];

            k = (k + 1) % 3;
            s = st + s;
        }

        if (iNum.Length % 3 != 0 && iNum.Length > 3) {
            iG = int.Parse(iNum[..(iNum.Length % 3)]);
            st = Group3(iG);
            st += strGroup[k];
            s = st + s;
        }

        s += Group3(int.Parse(iNum[Math.Max(iNum.Length - 3, 0)..]));
        if (s == "") s = "không";
        else if (s.StartsWith("không trăm lẻ")) s = s[14..];
        else if (s.StartsWith("không trăm ")) s = s[11..];

        return s.Trim();
    }

    private static string Group3(int iNum) {
        var iDg = new int[3];
        var sResult = new string[3];

        if (iNum == 0) return "";

        iDg[2] = iNum / 100;
        iDg[1] = iNum / 10 % 10;
        iDg[0] = iNum % 10;

        sResult[2] = strDigit[iDg[2]] + "trăm ";
        sResult[1] = iDg[1] switch {
            >= 2 => strDigit[iDg[1]] + "mươi ",
            1 => "mười ",
            0 => "lẻ ",
            _ => throw new ArgumentOutOfRangeException("iDg[1]")
        };

        sResult[0] = strDigit[iDg[0]];

        switch (iDg[0]) {
            case 0: {
                sResult[0] = "";
                if (iDg[1] == 0) sResult[1] = "";
                break;
            }
            case 1 when iDg[1] >= 2:
                sResult[0] = "mốt ";
                break;
            case 5 when iDg[1] >= 1:
                sResult[0] = "lăm ";
                break;
        }

        return sResult[2] + sResult[1] + sResult[0];
    }

    public static void Test() {
        long n;
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Định nghĩa dãy phát âm các ký số");
        Console.WriteLine($"{n = 100:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 123_456_000:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 23_456_000:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 3_005_000:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 505_000:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 500_000:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 5000_000:n0}:\n- {Read(n.ToString())}");
        Console.WriteLine($"{n = 2199285001:n0}:\n- {Read(n.ToString())}");
    }
}
