using System.Text.RegularExpressions;

namespace welearn.net.algo.piece.HackerRank;

public class ValidNumber {
    public bool IsNumber(string s) {
        const string pattern = @"^(((\+|-)?(((\d*)\.(\d+))|((\d+)\.(\d*))))|((\+|-)?\d+))(e(\+|-)?\d+)?$";
        return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
    }

    public bool IsNumberManual(string s) {
        bool allowDot = true,
            exp = false,
            allowExp = false,
            allowSign = true,
            expectAny = true
            ;

        foreach (var c in s) {
            if (c == '.') {
                if (!allowDot) return false;
                allowDot = false;
                allowSign = false;
                if (!exp && !expectAny) allowExp = true;
            } else if (c is 'e' or 'E') {
                if (exp || !allowExp) return false;
                exp = true;
                allowExp = false;
                allowSign = true;
                allowDot = false;
                expectAny = true;
            } else if (c is '+' or '-') {
                if (!allowSign) return false;
                allowSign = false;
                expectAny = true;
            } else if (c is >= '0' and <= '9') {
                allowSign = false;
                if (!exp) allowExp = true;
                expectAny = false;
            } else {
                return false;
            }
        }

        return !expectAny;
    }
}