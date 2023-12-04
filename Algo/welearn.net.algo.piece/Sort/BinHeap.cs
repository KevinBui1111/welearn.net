namespace welearn.net.algo.piece.Sort;

public class BinHeap<T> {
    private readonly IComparer<T> _comparer;
    private readonly T[] _array;
    private int _size;

    public BinHeap(T[] arr) : this(arr, Comparer<T>.Default) { }

    public BinHeap(T[] arr, IComparer<T> comparer) {
        _array = arr;
        _size = arr.Length;
        _comparer = comparer;

        BuildHeap();
    }

    private void BuildHeap() {
        for (var i = _size / 2 - 1; i >= 0; --i) {
            Heapify(_size, i);
        }
    }

    private void Heapify(int size, int i) {
        if (size == 1) return;

        do {
            int l = 2 * i + 1,
                r = 2 * i + 2;

            var child = r < size && _comparer.Compare(_array[l], _array[r]) < 0
                ? r
                : l;

            if (_comparer.Compare(_array[i], _array[child]) < 0)
                (_array[i], _array[child]) = (_array[child], _array[i]);
            else
                break;

            i = child;
        } while (2 * i + 1 < size);
    }

    public T Peek() => _array[0];

    public T? Pop() {
        if (_size == 0) return default;
        if (_size-- == 1) return _array[0];

        (_array[0], _array[_size]) = (_array[_size], _array[0]);
        Heapify(_size, 0);

        return _array[_size];
    }

    public void UpdateRoot(T obj) {
        _array[0] = obj;
        Heapify(_size, 0);
    }
}