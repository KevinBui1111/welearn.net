using welearn.net.easy;

namespace welearn.net.algo.piece.Combinatorics; 

public class Permutation {
    private IList<IList<int>> _result;
    public IList<IList<int>> Permute(int[] nums) {
        _result = new List<IList<int>>();
        Permute(nums, 0);
        return _result;
    }
    
    
    public void Permute(int[] nums, int n) {
        if (n == nums.Length - 1) {
            // nums.PrintConsole();
            _result.Add(nums.ToList());
            return;
        }

        Permute(nums, n + 1);
        
        for (var i = n + 1; i < nums.Length; ++i) {
            Swap(n, i);
            Permute(nums, n + 1);
            Swap(i, n); // back to previous state
        }

        return;

        void Swap(int x, int y) => (nums[x], nums[y]) = (nums[y], nums[x]);
    }

    public static void PermuteTest() {
        new Permutation().Permute(new[] { 1, 2, 3, 4 });
    }
}