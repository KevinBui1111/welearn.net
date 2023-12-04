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
            Heapify(arr, arr.Length, i);
        }
    }
    
    public void BuildMinHeap(int[] arr) {
        for (var i = arr.Length / 2 - 1; i >= 0; --i) {
            HeapifyMin(arr, arr.Length, i);
        }
    }

    private static void Heapify(int[] arr, int size, int i) {
        if (size == 1) return;

        do {
            int l = 2 * i + 1,
                r = 2 * i + 2;
            
            var child = r < size && arr[l] < arr[r] ? r : l;

            if (arr[i] < arr[child])
                (arr[i], arr[child]) = (arr[child], arr[i]);
            else
                break;

            i = child;

        } while (2 * i + 1 < size);
    }

    private static void HeapifyMin(int[] arr, int size, int i) {
        if (size == 1) return;

        do {
            int l = 2 * i + 1,
                r = 2 * i + 2;
            
            var child = r < size && arr[l] > arr[r] ? r : l;

            if (arr[i] > arr[child])
                (arr[i], arr[child]) = (arr[child], arr[i]);
            else
                break;

            i = child;

        } while (2 * i + 1 < size);
    }

    public void Sort(int[] arr) {
        BuildMaxHeap2(arr);
        
        var size = arr.Length;
        while (size-- > 1) {
            // remove root node
            (arr[0], arr[size]) = (arr[size], arr[0]);
            Heapify(arr, size, 0);
        }
    }
}