using welearn.net.easy;

namespace welearn.net.algo.ExactCover;

/// <summary>
/// Knuth's Algorithm X, exact cover problem
/// </summary>
public class SetupTeam {
    public static void Find(int n, int[][] candidates) {
        var skillsMark = new bool[n + 1];
        var candidatesMark = new bool[candidates.Length];
        var totalRemainingSkills = n;
        var successTeams = new List<int[]>();

        Find(0);

        successTeams.ForEach(t => t.PrintConsole());
        
        return;

        void Find(int from) {
            for (var i = from; i < candidates.Length; ++i) {
                if (canFit(candidates[i])) {
                    // join team
                    JoinTeam(i, join: true);
                    
                    if (StillNeedSkill())
                        // find next
                        Find(i + 1);
                    else {
                        // find out
                        successTeams.Add(ToTeam());
                    }
                    // leave team
                    JoinTeam(i, join: false);
                }
            }
        }

        int[] ToTeam() => candidatesMark.IndexOfWhere(c => c).ToArray();

        bool StillNeedSkill() => totalRemainingSkills > 0;

        void JoinTeam(int canIndex, bool join) {
            ToggleSkill(candidates[canIndex], on: join);
            candidatesMark[canIndex] = join;

            if (join)
                totalRemainingSkills -= candidates[canIndex].Length;
            else
                totalRemainingSkills += candidates[canIndex].Length;
        }

        void ToggleSkill(int[] skill, bool on) {
            foreach (var s in skill) {
                skillsMark[s] = on;
            }
        }

        bool canFit(int[] subSet) {
            for (var i = 0; i < subSet.Length; ++i) {
                if (skillsMark[subSet[i]]) return false;
            }

            return true;
        }
    }
    
    public static void Test() {
        Find(7, [
            [1, 4, 7],
            [1, 4],
            [4, 5, 7],
            [3, 5, 6],
            [2, 3, 6, 7],
            [2, 7]
        ]);
        Console.WriteLine("done");
    }
}