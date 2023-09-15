namespace welearn.net.algo.piece.HackerRank;

public class NextGreaterElement {
    // https://www.geeksforgeeks.org/next-greater-element/
    public static long[] next_greater_element1(long[] list) {
        long[] res = new long[list.Length];
        var wait_stack = new Stack<int>();
        for (int i = 0; i < list.Length; ++i) {
            int i_wait = -1;
            while (wait_stack.Count > 0 && list[i_wait = wait_stack.Peek()] < list[i]) {
                wait_stack.Pop();
                res[i_wait] = list[i];
            }

            res[i] = -1;
            wait_stack.Push(i);
        }

        return res;
    }

    public static long[] next_greater_element2(long[] list) {
        long[] res = new long[list.Length];
        for (int i = 0; i < list.Length; ++i) {
            for (int j = i - 1; j >= 0; --j) {
                if (res[j] == -1 && list[j] < list[i])
                    res[j] = list[i];
            }

            res[i] = -1;
        }

        return res;
    }

    public static int[] next_greater_element3(int[] list) {
        Enumerable.Repeat(-1, list.Length);
        int[] res = new int[list.Length];
        var wait_stack = new Stack<int>();
        for (int i = 0; i < 2 * list.Length; ++i) {
            int idx = i % list.Length;
            int i_wait = -1;
            while (wait_stack.Count > 0 && list[i_wait = wait_stack.Peek()] < list[idx]) {
                wait_stack.Pop();
                res[i_wait] = list[idx];
            }

            if (i == idx) {
                res[idx] = -1;
                wait_stack.Push(idx);
            }
        }

        return res;
    }

    // correct answer 2023-09-15 22:46
    public static int[] next_greater_element(int[] list) {
        var n = list.Length;
        var smallerIdx = new int[n];
        smallerIdx[0] = -1;

        var res = new int[n];
        for (var i = 1; i < n; ++i) {
            smallerIdx[i] = i - 1;
            var j = smallerIdx[i];
            while (j > -1 && list[j] < list[i]) {
                res[j] = list[i];
                j = smallerIdx[j];
            }

            smallerIdx[i] = j;
        }

        for (var i = n - 1; i >= 0;) {
            res[i] = -1;
            i = smallerIdx[i];
        }

        return res;
    }
}