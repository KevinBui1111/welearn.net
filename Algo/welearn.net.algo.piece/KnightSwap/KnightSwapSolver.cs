using System.Text;
using welearn.net.easy;

namespace welearn.net.algo.piece.KnightSwap;

public class KnightSwapSolver {
    private static readonly Dictionary<int, int[]> MapPath = new() {
        { 1, [5] },
        { 2, [6,7,9] },
        { 3, [8,10] },
        { 4, [10] },
        { 5, [1,7] },
        { 6, [2,8] },
        { 7, [2,5] },
        { 8, [3,6] },
        { 9, [2] },
        { 10, [3,4] },
    };

    public static int[] Solve() {
        const string? start = "1...1.0.0.";
        const string goal   = "0...0.1.1.";
        HashSet<string> visited = [start];
        Stack<Move> movesStack = new([new Move(start, "Start")]);
        // find all possible moves,
        while (movesStack.Count > 0) {
            var (currentState, path) = movesStack.Pop();
            var position = currentState.IndexOfWhere(c => c != '.');

            foreach (var from in position)
            foreach (var to in MapPath[from])
                // check if a previous move
                if (CanMove(currentState, from, to, out var newState)) {
                    var newPath = $"{path}-{from}{to}";
                    if (newState == "10..1...0.")
                        Console.WriteLine($"Debug! {newPath}");
                    if (newState == goal)
                        Console.WriteLine($"Found goal! {newPath}");
                    else if (visited.Add(newState))
                        movesStack.Push(new Move(newState, newPath));
                }
        }

        return [];

        bool CanMove(string state, int from, int to, out string newMove) {
            var valid = state[from - 1] != '.' && state[to - 1] == '.';
            newMove = valid ? Move(state, from, to) : string.Empty;
            return valid;
        }

        string Move(string state, int from, int to) {
            var newState = new StringBuilder(state);
            newState[to-1] = newState[from-1];
            newState[from-1] = '.';
            return newState.ToString();
        }
    }

    private record Move(string State, string Path);
    public static void Test() {
        Solve();
    }
}