using System.Text;
using welearn.net.easy;

namespace welearn.net.algo.ExactCover;

/// <summary>
/// solution from a Dung (Head)
/// </summary>
public class SetupTeamHashSet {
    static String setToString<T>(HashSet<T> set) {
        StringBuilder res = new StringBuilder();
        res.Append("{");
        set.ToList().ForEach(st => res.Append(st + ","));
        if (set.Count > 0) res.Remove(res.Length - 1, 1);
        res.Append("}");
        return res.ToString();
    }

    static HashSet<T> SetAdd<T>(HashSet<T> a, HashSet<T> b) {
        HashSet<T> r = new HashSet<T>(a);
        r.UnionWith(b);
        return r;
    }

    static HashSet<T> SetAddElement<T>(HashSet<T> a, T b) {
        HashSet<T> r = new HashSet<T>(a);
        r.Add(b);
        return r;
    }

    static HashSet<T> SetMinus<T>(HashSet<T> a, HashSet<T> b) {
        HashSet<T> r = new HashSet<T>(a);
        r.RemoveWhere(x => b.Contains(x));
        return r;
    }

    static HashSet<T> SetMinusElement<T>(HashSet<T> a, T b) {
        HashSet<T> r = new HashSet<T>(a);
        r.Remove(b);
        return r;
    }


    static List<MySet<int>> F(MySet<int> setCandidates, MySet<String> requiredSkills, MySet<int> setTeam, MySet<String> usedSkills) {
        List<MySet<int>> res = new List<MySet<int>>();

        // no more skill to find? the current team is the final team, return it 
        if (requiredSkills.Count == 0) {
            return new List<MySet<int>>() { setTeam };
        }

        // no more candidate to add to team ==> failed 
        if (setCandidates.Count == 0) {
            return new List<MySet<int>>();
        }

        // if we can add first member to team, find solutions with new candidate set containing the first candidate
        int first = setCandidates.First();
        MySet<String> firstSkills = candidates[first];
        if (!firstSkills.Overlaps(usedSkills) && firstSkills.IsSubsetOf(requiredSkills)){
            res.AddRange(
                F(setCandidates - first,requiredSkills - firstSkills,setTeam + first, usedSkills + firstSkills)
            );

        }

        // find solution(s) with new candidates set WITHOUT choosing first candidate
        res.AddRange(
            F(setCandidates - first, requiredSkills, setTeam, usedSkills)
        );

        return res;
    }
    
    public class MySet<T>: HashSet<T> {
        public MySet(): base() {}

        public MySet(MySet<T> s): base(s) { }

        public override String ToString() {
            StringBuilder res = new StringBuilder();
            res.Append("{");
            this.ToList().ForEach(st => res.Append(st + ","));
            if (this.Count > 0) res.Remove(res.Length - 1, 1);
            res.Append("}");
            return res.ToString();
        }
    
        public static MySet<T> operator +(MySet<T> a, MySet<T> b) {
            MySet<T> r = new MySet<T>(a);
            r.UnionWith(b);
            return r;
        }

        public static MySet<T> operator +(MySet<T> a, T b) {
            MySet<T> r = new MySet<T>(a);
            r.Add(b);
            return r;
        }

        public static MySet<T> operator -(MySet<T> a, MySet<T> b) {
            MySet<T> r = new MySet<T>(a);
            r.RemoveWhere(x => b.Contains(x));
            return r;
        }

        public static MySet<T> operator -(MySet<T> a, T b) {
            MySet<T> r = new MySet<T>(a);
            r.Remove(b);
            return r;
        }
    }

    private static Dictionary<int, MySet<string>> candidates;
    public static void Test() {
        candidates = new Dictionary<int, MySet<string>> {
            { 1, ["Java", "Database", "NodeJS"] },
            { 2, ["Java", "Database"] },
            { 3, ["Database", "Python", "NodeJS"] },
            { 4, [".NET", "Python", "Go"] },
            { 5, ["C++", ".NET", "Go", "NodeJS"] },
            { 6, ["C++", "NodeJS"] },
        };

        var ss = F([1, 2, 3, 4, 5, 6],
            ["Java", "C++", ".NET", "Database", "Python", "Go", "NodeJS"],
            [],
            []
        );

        candidates = new Dictionary<int, MySet<string>> {
            { 1, [".NET", "Go", "NodeJS", "Kotlin"] },
            { 2, ["Kotlin"] },
            { 3, ["Java", "Database", "NodeJS"] },
            { 4, ["Database", "Python", "Scala"] },
            { 5, ["Java", "C++"] },
            { 6, [".NET", "Python", "Go"] },
            { 7, [".NET", "Database", "Kotlin"] },
            { 8, ["Python", "Go"] },
            { 9, ["C++", "Scala"] },
            { 10, ["NodeJS", "Scala"] },
        };

        ss = F([1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            ["Java", "C++", ".NET", "Database", "Python", "Go", "NodeJS", "Scala", "Kotlin"],
            [],
            []
        );

        ss.ForEach( subSet => Console.Write( subSet.ToString() ) );
    }
    public static List<MySet<int>> TestBm() {
        candidates = new Dictionary<int, MySet<string>> {
            { 1, [".NET", "Go", "NodeJS", "Kotlin"] },
            { 2, ["Kotlin"] },
            { 3, ["Java", "Database", "NodeJS"] },
            { 4, ["Database", "Python", "Scala"] },
            { 5, ["Java", "C++"] },
            { 6, [".NET", "Python", "Go"] },
            { 7, [".NET", "Database", "Kotlin"] },
            { 8, ["Python", "Go"] },
            { 9, ["C++", "Scala"] },
            { 10, ["NodeJS", "Scala"] },
        };

        return F([1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            ["Java", "C++", ".NET", "Database", "Python", "Go", "NodeJS", "Scala", "Kotlin"],
            [],
            []
        );
    }
}