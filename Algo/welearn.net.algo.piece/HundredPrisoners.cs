using System.Text;
using welearn.net.easy;

namespace welearn.net.algo.piece; 

/// <summary>
/// Move from ConsoleApp project, build: 2022-07-21
/// </summary>
internal static class HundredPrisoners {
    internal static void Test() {
        const int prisonerNo = 1000;
        const int testNo = 1_000_000;
        var success = 0;
        var arrInt = Enumerable.Range(1, prisonerNo).ToArray();
        for (var i = 0; i < testNo; ++i) {
            ListUtil.Shuffle(arrInt);
            // arrInt = new[] { 4, 2, 7, 5, 10, 9, 6, 8, 1, 3 };
            // Console.WriteLine(string.Join(", ", arrInt));

            // var loops = findLoops(arrInt);
            // printLoops(loops);
            success += TestLoops(arrInt) ? 1 : 0;
                
            // Console.WriteLine($"======{success}=======");
        }
        Console.WriteLine($"Success rate: {1.0 * success / testNo}");
    }

    private static List<List<int>> FindLoops(IReadOnlyList<int> arrInt) {
        // 4, 2, 7, 5, 10, 9, 6, 8, 1, 3
        // (4, 5, 10, 3, 7, 6, 9, 1)(2)(8)

        var arrLoops = new List<List<int>>();
        var marks = new int[arrInt.Count];
        for (var i = 0; i < arrInt.Count; ++i) {
            if (marks[i] == -1) continue;

            var loop = new List<int>();

            var k = i;
            do {
                loop.Add(arrInt[k]);
                marks[k] = -1;
                k = arrInt[k] - 1;
            } while (k != i);
                
            arrLoops.Add(loop);
        }

        return arrLoops;
    }

    private static bool TestLoops(IReadOnlyList<int> arrInt) {
        var failedLength = arrInt.Count / 2 + 1; 

        var marks = new int[arrInt.Count];
        var checkNo = 0;
        for (var i = 0; i < arrInt.Count; ++i) {
            if (marks[i] == -1) continue;

            var loop = new List<int>();

            var k = i;
            do {
                loop.Add(arrInt[k]);
                marks[k] = -1;
                k = arrInt[k] - 1;
            } while (k != i && loop.Count < failedLength);

            if (loop.Count >= failedLength) return false;
            checkNo += loop.Count;
            if (checkNo >= failedLength - 1) return true;
        }

        return true;
    }

    private static void PrintLoops(List<List<int>> arrLoops) {
        var sb = new StringBuilder();
        foreach (var loop in arrLoops) {
            sb.Append($"({string.Join(", ", loop)})");
        }
            
        Console.WriteLine(sb);
    }
}