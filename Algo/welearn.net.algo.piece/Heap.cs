namespace welearn.net.algo.piece; 

public class Heap {
    public void BuildMaxHeap(int[] arr) {
        for (var i = 1; i < arr.Length; ++i) {
            var j = i;
            var parentIdx = (j - 1) / 2;
            while (j > 0 && arr[parentIdx] < arr[j]) {
                (arr[j], arr[parentIdx]) = (arr[parentIdx], arr[j]);
                j = parentIdx;
                parentIdx = (j - 1) / 2;
            }
        }
    }
}