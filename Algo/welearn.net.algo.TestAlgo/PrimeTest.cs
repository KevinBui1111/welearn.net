using System.Runtime.Serialization;
using welearn.net.algo.prime;

namespace welearn.net.algo.TestAlgo;

/// <summary>
/// Move from ConsoleApp project, change to xUnit instead of MSTest
/// Build since 2023-02-08
/// </summary>
public class PrimeTest {
    [Fact]
    public void NthPrime() {
        int[] primeNth = {
            1, 2, 3, 10, 11, 99, 100, 1111, 2804, 1_000_000,
            19881111, 19920428, 2023_02_08 /*, 1_000_000_000*/
        };
        long[] expected = {
            2, 3, 5, 29, 31, 523, 541, 8933, 25439, 15_485_863,
            371_240_333, 372015493, 378_120_053 /*, 22_801_763_489*/
        };
        var actual = primeNth.AsParallel().Select(Prime.NthPrime);
        Assert.Equal(expected, actual.ToArray());
    }
    
    public static IEnumerable<object[]> NthPrimeTestData {
        get {
            int[] primeNth = {
                1, 2, 3, 10, 11, 99, 100, 1111, 2804, 1_000_000,
                19881_111, 19_920_428, 2023_02_08 /*, 1_000_000_000*/
            };
            long[] expected = {
                2, 3, 5, 29, 31, 523, 541, 8933, 25439, 15_485_863,
                371_240_333, 372_015_493, 378_120_053 /*, 22_801_763_489*/
            };

            return primeNth.Select(
                (nTh, index) => new object[] { nTh, expected[index] }
            );
        }
    }

    [Theory] // not support to run in parallel! 
    [MemberData(nameof(NthPrimeTestData))]
    public void NthPrime2(int nTh, int expected) {
        var actual = Prime.NthPrime(nTh);
        Assert.Equal(expected, actual);
    }

    private readonly int[] _expectedBound1000 = {
        2, 3, 5, 7, 11, 13, 17, 19, 23,
        29, 31, 37, 41, 43, 47, 53, 59, 61, 67,
        71, 73, 79, 83, 89, 97, 101, 103, 107, 109,
        113, 127, 131, 137, 139, 149, 151, 157, 163, 167,
        173, 179, 181, 191, 193, 197, 199, 211, 223, 227,
        229, 233, 239, 241, 251, 257, 263, 269, 271, 277,
        281, 283, 293, 307, 311, 313, 317, 331, 337, 347,
        349, 353, 359, 367, 373, 379, 383, 389, 397, 401,
        409, 419, 421, 431, 433, 439, 443, 449, 457, 461,
        463, 467, 479, 487, 491, 499, 503, 509, 521, 523,
        541, 547, 557, 563, 569, 571, 577, 587, 593, 599,
        601, 607, 613, 617, 619, 631, 641, 643, 647, 653,
        659, 661, 673, 677, 683, 691, 701, 709, 719, 727,
        733, 739, 743, 751, 757, 761, 769, 773, 787, 797,
        809, 811, 821, 823, 827, 829, 839, 853, 857, 859,
        863, 877, 881, 883, 887, 907, 911, 919, 929, 937,
        941, 947, 953, 967, 971, 977, 983, 991, 997
    };

    [Fact]
    public void SieveEratosthenes() {
        var actual = Prime.SieveEratosthenes(1000);
        Assert.Equal(_expectedBound1000, actual);
    }

    [Fact]
    public void Sieve22Max() {
        var actual = Prime.Sieve22Max(1000);
        Assert.Equal(_expectedBound1000, actual);
    }

    [Fact]
    public void Sieve22Max_Naive() {
        var primeList = Prime.Sieve22Max_Naive(1_000_000_000);
        var lastActual = (primeList.Count, primeList[^1]);
        var expected = (50_847_534, 999999937);
        Assert.Equal(lastActual, expected);
    }

    [Fact]
    public void LastPrime() {
        var actual = Prime.LastPrime(4_611_686_014_132_420_609);
        const long expected = 4_611_686_014_132_420_493;
        Assert.Equal(actual, expected);
    }
}