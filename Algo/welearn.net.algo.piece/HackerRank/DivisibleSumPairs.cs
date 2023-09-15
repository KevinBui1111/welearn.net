namespace welearn.net.algo.piece.HackerRank; 

public class DivisibleSumPairs {
    // move from ConsoleCore project, 2020-10-29 13:24
    // https://www.hackerrank.com/challenges/divisible-sum-pairs/problem
    public static int HowMany(int k, IEnumerable<int> ar)
    {
        int[] remainders = new int[k];
        int sum = 0;
        foreach(int a in ar)
        {
            sum += remainders[(k - a % k) % k];
            ++remainders[a % k];
        }
        return sum;
    }
}