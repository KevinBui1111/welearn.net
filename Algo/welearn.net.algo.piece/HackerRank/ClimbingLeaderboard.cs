using System.Diagnostics;

namespace welearn.net.algo.piece.HackerRank;

public class ClimbingLeaderboard {
    // move from ConsoleCore project, 2020-10-29 13:24
    
    /*
     * https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */
    public static List<int> ClimbingLeaderBoard(List<int> ranked, List<int> player) {
        //100 100 50 40 40 20 10
        //5 25 50 120
        int[] res = new int[player.Count];

        int rank = 0;
        int prev_score = int.MaxValue;
        int i = 0, j = player.Count - 1;
        while (i < ranked.Count && j >= 0) {
            if (prev_score > ranked[i]) {
                ++rank;
                prev_score = ranked[i];
            }

            if (player[j] >= ranked[i]) {
                res[j--] = rank;
                continue;
            }
            else {
                ++i;
            }
        }

        ++rank;
        while (j >= 0) {
            res[j--] = rank;
        }

        return res.ToList();
    }
}

internal class Solution {
    public static void Main2(string[] args) {
        using (var sr = new StreamReader("in.txt")) {
            Console.SetIn(sr);

            List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList()
                .Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();
            List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList()
                .Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> result = ClimbingLeaderboard.ClimbingLeaderBoard(ranked, player);

            TextWriter textWriter = new StreamWriter("out.txt");

            sw.Stop();
            Console.WriteLine($"complete in {sw.Elapsed}!");

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }

        Console.ReadKey();
    }
}