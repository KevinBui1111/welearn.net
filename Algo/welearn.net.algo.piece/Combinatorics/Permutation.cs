using welearn.net.easy;

namespace welearn.net.algo.piece.Combinatorics;

public class Permutation {
    private IList<IList<byte>> _result;
    private byte[] _nums;

    private void Prepare(byte[] nums) {
        _result = new List<IList<byte>>();
        _nums = nums;
    }
    public IList<IList<byte>> Permute(byte[] nums) {
        Prepare(nums);
        Permute(0);
        return _result;
    }

    public IList<IList<byte>> PermuteHeap(byte[] nums) {
        Prepare(nums);
        PermuteHeap(nums.Length);
        return _result;
    }

    public void Permute(int n) {
        if (n == _nums.Length - 1) {
            // nums.PrintConsole();
            _result.Add(_nums.ToList());
            return;
        }

        Permute(n + 1);

        for (var i = n + 1; i < _nums.Length; ++i) {
            Swap(n, i);
            Permute(n + 1);
            Swap(i, n); // back to previous state
        }
    }

    public void PermuteHeap(int n) {
        if (n == 1) {
            // _nums.PrintConsole();
            _result.Add(_nums.ToList());
            return;
        }

        PermuteHeap(n - 1);

        for (var i = 0; i < n - 1; ++i) {
            Swap(n % 2 == 0 ? i : 0, n - 1);
            PermuteHeap(n -1);
        }
    }

    private void Swap(int x, int y) => (_nums[x], _nums[y]) = (_nums[y], _nums[x]);


    public static void PermuteTest() {
        new Permutation().Permute(new byte[] { 1, 2, 3, 4 });
    }
}