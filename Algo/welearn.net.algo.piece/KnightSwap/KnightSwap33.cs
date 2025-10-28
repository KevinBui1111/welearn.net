using System.Text;
using welearn.net.easy;

namespace welearn.net.algo.piece.KnightSwap;
// https://www.youtube.com/watch?v=EuDnVV8j_Zs
public class KnightSwap33 {
    private static readonly Dictionary<int, int[]> MapPath = new() {
        { 0, [5,7] },
        { 1, [6,8] },
        { 2, [3,7] },
        { 3, [2,8,10] },
        { 4, [9,11] },
        { 5, [0,6,10] },
        { 6, [1,5,11] },
        { 7, [0,2] },
        { 8, [1,3,9] },
        { 9, [4,8] },
        { 10, [3,5] },
        { 11, [4,6] },
    };

    public static int[] Solve() {
        const string start = "111......000";
        const string goal  = "000......111";
        HashSet<string> visited = [$"{start}-1"];
        Queue<Move> movesStack = new([new Move(start, '1', "Start")]);
        // find all possible moves,
        while (movesStack.Count > 0) {
            var (currentState, turn, path) = movesStack.Dequeue();
            var position = currentState.IndexOfWhere(c => c == turn, false);
            var nextTurn = (char)(97 - turn);

            foreach (var from in position)
            foreach (var to in MapPath[from])
                if (CanMove(currentState, from, to, out var newState)) {
                    var newPath = $"{path}-{from}{to}";
                    if (newState == goal)
                        Console.WriteLine($"Found goal! {newPath}");
                    else if (visited.Add($"{newState}-{nextTurn}"))
                        movesStack.Enqueue(new Move(newState, nextTurn, newPath));
                }
        }

        return [];
    }

    private static bool CanMove(string state, int from, int to, out string newMove) {
        var valid = state[from] != '.' && state[to] == '.';
        newMove = valid ? Move() : string.Empty;
        return valid;

        string Move() {
            var newState = new StringBuilder(state);
            newState[to] = newState[from];
            newState[from] = '.';
            return newState.ToString();
        }
    }

    private record Move(string State, char Turn, string Path);
    public static void Test() {
        Solve();
    }
}