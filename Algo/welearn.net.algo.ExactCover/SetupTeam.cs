using welearn.net.easy;

namespace welearn.net.algo.ExactCover;

/*
Knuth's Algorithm X, exact cover problem
Lập ra team gồm candidates có đủ kỹ năng cho trước

vd:
kỹ năng cần có của team {
- biết python
- biết java
- giỏi giao tiếp (SOCIAL)
- biết automation test (AT)
- biết quản lý (MAN)
- biết phân tích data (DA)
- biết kiến trúc hệ thống (SA)
}

Candidate 1: { SOCIAL, MAN, DA }
Candidate 2: { python, AT, SA }
Candidate 3: { AT, MAN, SA }
Candidate 4: { java, SA }
Candidate 5: { python, AT }
Candidate 6: { java, SOCIAL, DA, SA }

Với input trên, thì Team cần lập gồm các candidate: 1, 4, 5
--
Team cần thỏa điều kiện:
- phải cover đủ kỹ năng đề ra
- team member không trùng kỹ năng với nhau
Không tìm được thì báo trả mảng rỗng
*/
public class SetupTeam {
    public static List<int[]> FindTeam(int n, int[][] candidates) {
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
        successTeams.ForEach(t => t.PrintConsole());
        Console.WriteLine("done");
        
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
        successTeams.ForEach(t => t.PrintConsole());
        Console.WriteLine("done");
    }
}