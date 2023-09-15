using System.Diagnostics;
using System.Reflection;

namespace welearn.net.algo.piece.HackerRank;

public static class ClimbingLeaderBoard {
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
    public static IEnumerable<int> Ranking(List<int> ranked, List<int> player) {
        //100 100 50 40 40 20 10
        //5 25 50 120
        var res = new int[player.Count];

        var rank = 0;
        var prevScore = int.MaxValue;
        int i = 0, j = player.Count - 1;
        while (i < ranked.Count && j >= 0) {
            if (prevScore > ranked[i]) {
                ++rank;
                prevScore = ranked[i];
            }

            if (player[j] >= ranked[i]) {
                res[j--] = rank;
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
