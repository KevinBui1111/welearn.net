namespace welearn.net.algo.piece; 

public class Heap {
    public void BuildMaxHeap(int[] arr) {
        for (var i = 1; i < arr.Length; ++i) {
            Add(arr, i);
        }
    }

    private static void Add(int[] arr, int lastIdx) {
        var parentIdx = (lastIdx - 1) / 2;
        while (lastIdx > 0 && arr[parentIdx] < arr[lastIdx]) {
            (arr[lastIdx], arr[parentIdx]) = (arr[parentIdx], arr[lastIdx]);
            lastIdx = parentIdx;
            parentIdx = (lastIdx - 1) / 2;
        }
    }
    
    public void BuildMaxHeap2(int[] arr) {
        for (var i = arr.Length / 2 - 1; i >= 0; --i) {
            Heapify(arr, i);
        }
    }

    private static void Heapify(int[] arr, int idx) {
        do {
            int left = 2 * idx + 1,
                right = 2 * idx + 2;
            
            var child =
                right < arr.Length &&
                arr[left] < arr[right]
                    ? right
                    : left;

            if (arr[idx] < arr[child])
                (arr[idx], arr[child]) = (arr[child], arr[idx]);
            else
                break;

            idx = child;

        } while (2 * idx + 1 < arr.Length);
    }
}