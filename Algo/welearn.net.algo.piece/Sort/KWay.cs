namespace welearn.net.algo.piece.Sort; 

public class KWay {
    public int[] Sort(int[][] arrays) {
        var result = new List<int>();
        // var heap = new BinHeap<int[]>(arrays, ((ints1, ints2) => ints1[0] - ints2[0]));
        var heap = new BinHeap<(int[] array, int idx)>(
            arrays.Where(a => a?.Length > 0).Select(a => (array: a, idx: 0)).ToArray(),
            (n1, n2) => n1.array[n1.idx] - n2.array[n2.idx] 
        );
        while (!heap.IsEmpty) {
            var max = heap.Peek();
            result.Add(max.array[max.idx++]);
            
            if (max.idx < max.array.Length) { // not reach last
                heap.UpdateRoot(max);
            } else { // reach end of array
                heap.Pop();
            }
        }

        return result.ToArray();
    }
}