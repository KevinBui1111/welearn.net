using welearn.net.easy;

namespace welearn.net.algo.ExactCover;

/*
Knuth's Algorithm X, exact cover problem
*/
public class SetupTeamV2 {
    public static List<int[]> FindTeam(int n, int[][] candidates) {
        var matrix = new int[candidates.Length, n];

        var headColumnNodes = new Head[n + 1];
        var lastColumnNodes = new Node[n + 1];
        var head = lastColumnNodes[0] = headColumnNodes[0] = new Head();
        var prev = head;
        for (var i = 1; i < n + 1; ++i) {
            var current = new Head { Left = prev };
            prev = prev.Right = lastColumnNodes[i] = headColumnNodes[i] = current;
        }

        foreach (var c in candidates) {
            prev = null;
            foreach (var skill in c) {
                var current = new Node {
                    Value = skill,
                    Left = prev,
                    Above = lastColumnNodes[skill]
                };
                if (prev != null)
                    prev.Right = current;

                prev = current;

                lastColumnNodes[skill] = lastColumnNodes[skill].Down = prev;

                ++headColumnNodes[skill].Count;
            }
        }

        return null;
        var skillsMark = new bool[n + 1];
        var candidatesMark = new bool[candidates.Length];
        var totalRemainingSkills = n;
        var successTeams = new List<int[]>();

        Find(0);

        return successTeams;

        void Find(int from) {
            for (var i = from; i < candidates.Length; ++i) {
                if (!CanFit(candidates[i])) continue;

                // join team
                JoinTeam(i, join: true);
                    
                if (StillNeedSkill()) // find next
                    Find(i + 1);
                else // find out
                    successTeams.Add(ToTeam());
                // leave team
                JoinTeam(i, join: false);
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

        bool CanFit(int[] candidate) {
            for (var i = 0; i < candidate.Length; ++i) {
                if (skillsMark[candidate[i]]) return false;
            }

            return true;
        }
    }
    
    
    
    public static void Test() {
        var successTeams = FindTeam(7, [
            [1, 4, 7],
            [1, 4],
            [4, 5, 7],
            [3, 5, 6],
            [2, 3, 6, 7],
            [2, 7]
        ]);
        // successTeams.ForEach(t => t.PrintConsole());
        // Console.WriteLine("done");
        
        successTeams = FindTeam(9, [
            [3, 6, 7, 9],
            [9],
            [1, 4, 7],
            [4, 5, 8],
            [1, 2],
            [3, 5, 6],
            [3, 4, 9],
            [5, 6],
            [2, 8],
            [7, 8],
        ]);
        // successTeams.ForEach(t => t.PrintConsole());
        // Console.WriteLine("done");
    }
    
    public static List<int[]> TestBm() {
        return FindTeam(9, [
            [3, 6, 7, 9],
            [9],
            [1, 4, 7],
            [4, 5, 8],
            [1, 2],
            [3, 5, 6],
            [3, 4, 9],
            [5, 6],
            [2, 8],
            [7, 8],
        ]);
    }
}