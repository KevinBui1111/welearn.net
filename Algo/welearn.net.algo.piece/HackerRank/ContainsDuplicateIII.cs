namespace welearn.net.algo.piece.HackerRank; 

public class ContainsDuplicateIII {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff) {
        var indexes = Enumerable.Range(0, nums.Length).ToArray();
        Array.Sort(nums, indexes);
        
        for (var i = 0; i < nums.Length; ++i)
        for (var j = i + 1; j < nums.Length && Math.Abs(nums[i] - nums[j]) <= valueDiff; ++j)
            if (Math.Abs(indexes[i] - indexes[j]) <= indexDiff)
                return true;
        return false;
    }

    public static void Test() {
        int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 1 };
        var indexes = Enumerable.Range(0, a.Length).ToArray();
        Array.Sort(a, indexes);
    }
}