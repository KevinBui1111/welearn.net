using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class ValidNumberTest {
    public static IEnumerable<object[]> ValidNumberData {
        get {
            foreach (var s in new[] {
                         "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10",
                         "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789",
                         "1.e1", "1.e-1"
                     }) {
                yield return new object[] { s, true };
            }

            foreach (var s in new[] {
                         "abc", "1a", "1e", "e3", "6+1", "-1e.3", "05e-3.1",
                         "99e2.5", "--6", "-+3", "95a54e53", "+.5e.3", ".e+1",
                         "1.e", "-.e3", ".-4"
                     }) {
                yield return new object[] { s, false };
            }
        }
    }

    [Theory]
    [MemberData(nameof(ValidNumberData))]
    public void TestByRegex(string s, bool expected) {
        var actual = new ValidNumber().IsNumber(s);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(ValidNumberData))]
    public void TestByManual(string s, bool expected) {
        var actual = new ValidNumber().IsNumberManual(s);
        Assert.Equal(expected, actual);
    }
}