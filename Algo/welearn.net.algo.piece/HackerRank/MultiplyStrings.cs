using welearn.net.easy;

namespace welearn.net.algo.piece.HackerRank; 

//https://leetcode.com/problems/multiply-strings/
public static class MultiplyStrings {
    public static string Multiply(string num1, string num2) {
        const int limitPart = 10_000;
        const int sizePart = 4;
        // split part 4 digit, by limitPart.
        var partNum1 = PartString2(num1, sizePart);
        var partNum2 = PartString2(num2, sizePart);

        var resultPart = new int[partNum1.Count + partNum2.Count];
        for (var i = 0; i < resultPart.Length; ++i)
            resultPart[i] = 0;
        
        var indexResult1 = 0;
        var indexResult2 = 0;
        foreach (var p2 in partNum2) {
            indexResult2 = indexResult1;
            foreach (var p1 in partNum1) {
                var product = p2 * p1 + resultPart[indexResult2];
                var carry = product % limitPart;
                product /= limitPart;

                resultPart[indexResult2++] = carry;
                resultPart[indexResult2] += product;
            }

            ++indexResult1;
        }

        var result = "";
        for (var i = indexResult2; i >=0; --i) {
            result += resultPart[i].ToString().PadLeft(4, '0');
        }

        result = string.Join("", result.SkipWhile(c => c == '0'));

        return string.IsNullOrEmpty(result) ? "0" : result;
    }

    private static List<int> PartString(string num, int size) {
        //01 2345 6789
        //02 1234 5678
        var res = new List<int>();
        var i = num.Length - 4;
        string part;
        while (i >= 0) {
            part = num.Substring(i, 4);
            res.Add(int.Parse(part));

            i -= 4;
        }

        i += 4;
        
        if (i <= 0) return res;
        
        part = num[..i];
        res.Add(int.Parse(part));

        return res;
    }

    private static List<int> PartString2(string num, int size) {
        num = new string('0', (4 - num.Length % size) % size) + num;
        return Enumerable.Range(0, num.Length / size)
            .Select(i => num.Substring(i * size, size))
            .Select(int.Parse)
            .Reverse()
            .ToList();
    }

    public static void Test() {
    }
}