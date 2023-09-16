namespace welearn.net.algo.piece.HackerRank;

public class NextGreaterElement {
    // https://www.geeksforgeeks.org/next-greater-element/
    public static int[] next_greater_element1(int[] list) {
        int[] res = new int[list.Length];
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

    // answer 2023-09-15 22:46
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

    /*
       ask ChatGPT 3.5:
       - Given an array arr[ ] of size N having elements, the task is to find the next greater element
         for each element of the array in order of their appearance in the array.
         Next greater element of an element in the array is the nearest element on the right
         which is greater than the current element.
         If there does not exist next greater of current element, then next greater element
         for current element is -1. For example, next greater of the last element is always -1.

         Your Task:
         This is a function problem. You only need to complete the function nextLargerElement() that
         takes list of integers arr[] and N as input parameters and returns list of integers of length N
         denoting the next greater elements for all the corresponding elements in the input array.
         Implement in C#.

         ChatGPT 3.5 answer:
         You can solve this problem using a stack to keep track of elements in the array for which
         we haven't found the next greater element yet.
         Here's a C# implementation of the nextLargerElement() function:
     */
    public static List<int> NextLargerElementChatGpt(List<int> arr, int N) {
        List<int> result = new List<int>();
        Stack<int> stack = new Stack<int>();

        // Initialize the result list with -1 for all elements
        for (int i = 0; i < N; i++) {
            result.Add(-1);
        }

        for (int i = 0; i < N; i++) {
            // While the stack is not empty and the current element is greater
            // than the element at the index stored in the stack, update the result
            while (stack.Count > 0 && arr[i] > arr[stack.Peek()]) {
                int index = stack.Pop();
                result[index] = arr[i];
            }

            // Push the current element's index onto the stack
            stack.Push(i);
        }

        return result;
    }
    /*
     * In this code:
        1. We create a stack to keep track of the indices of elements in arr
           for which we haven't found the next greater element yet.
        2. We initialize a result list with -1 for all elements,
           assuming there is no greater element initially.
        3. We iterate through the elements of the input array from left to right.
        4. While the stack is not empty and the current element is greater than
           the element at the index stored in the stack,
           we update the result and pop elements from the stack.
        5. We push the current element's index onto the stack.
        6. Finally, we return the result list containing the next greater elements
           for each element in the input array.
     */
}