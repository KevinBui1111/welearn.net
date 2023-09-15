namespace welearn.net.algo.piece.HackerRank;

public class MinMaxRiddle {
    // Complete the riddle function below.
    public static long[] riddle_naive(long[] arr) =>
        Enumerable.Range(1, arr.Length).Select(i =>
            Enumerable.Range(0, arr.Length - i + 1).Max(j =>
                arr.Skip(j).Take(i).Min()
            )
        ).ToArray();

    public static long[] riddle_better(long[] arr) {
        // complete this function
        long[] res = new long[arr.Length];
        res[0] = arr.Max();
        for (int i = 1; i < arr.Length; ++i) {
            long max = -1;
            for (int j = 1; j <= arr.Length - i; ++j) {
                if (arr[j - 1] > arr[j])
                    arr[j - 1] = arr[j];

                if (arr[j - 1] > max)
                    max = arr[j - 1];
            }

            res[i] = max;
        }

        return res;
    }

    public static long[] Riddle(long[] arr) {
        // next smaller;
        int[] next = new int[arr.Length];
        var wait_stack = new Stack<int>();
        for (int i = 0; i < arr.Length; ++i) {
            int i_wait;
            while (wait_stack.Count > 0 && arr[i_wait = wait_stack.Peek()] > arr[i]) {
                wait_stack.Pop();
                next[i_wait] = i;
            }

            next[i] = arr.Length;
            wait_stack.Push(i);
        }

        // prev smaller;
        int[] prev = new int[arr.Length];
        wait_stack = new Stack<int>();
        for (int i = 0; i < arr.Length; ++i) {
            while (wait_stack.Count > 0 && arr[wait_stack.Peek()] >= arr[i]) {
                wait_stack.Pop();
            }

            prev[i] = wait_stack.Count > 0 ? wait_stack.Peek() : -1;
            wait_stack.Push(i);
        }

        long[] res = Enumerable.Repeat(-999L, arr.Length).ToArray();
        for (int i = 0; i < arr.Length; ++i) {
            int win_size = next[i] - prev[i] - 2;
            res[win_size] = arr[i] > res[win_size] ? arr[i] : res[win_size];
        }

        for (int i = arr.Length - 2; i > -1; --i) {
            res[i] = res[i] > res[i + 1] ? res[i] : res[i + 1];
            //if (res[i] == -999)
            //    res[i] = res[i + 1];
        }

        return res;
    }
}