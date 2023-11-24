using System.Collections;

namespace welearn.net.algo.piece.HackerRank; 

//https://leetcode.com/problems/contains-duplicate-iii/description/
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
    
    // reference to https://leetcode.com/problems/contains-duplicate-iii/solutions/61645/ac-o-n-solution-in-java-using-buckets-with-explanation/
    public bool Contains2(int[] nums, int indexDiff, int valueDiff) {
        var buckets = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++) {
            var n = nums[i];
            var bucketIndex = GetBucket(n);
            if (buckets.ContainsKey(bucketIndex)) return true;

            if (buckets.TryGetValue(bucketIndex + 1, out var nG) &&
                nG - n <= valueDiff) return true;

            if (buckets.TryGetValue(bucketIndex - 1, out var nL) &&
                n - nL <= valueDiff) return true;

            if (indexDiff <= i) {
                var bucketOld = GetBucket(nums[i - indexDiff]);
                buckets.Remove(bucketOld);
            }

            buckets[bucketIndex] = n;
        }

        return false;

        int GetBucket(int n) => (n - int.MinValue / 2) / (valueDiff + 1);
    }
    
    // reference to https://leetcode.com/problems/contains-duplicate-iii/solutions/1850389/c-simple-solution/
    public bool Contains3(int[] nums, int indexDiff, int valueDiff) {
        var sortedSet = new SortedSet<int>();

        for (var i = 0; i < nums.Length; i++) {
            var n = nums[i];
            var view = sortedSet.GetViewBetween(n - valueDiff, n + valueDiff);
            if (view.Count > 0) return true;

            if (indexDiff <= i) sortedSet.Remove(nums[i - indexDiff]);
            
            sortedSet.Add(n);
        }

        return false;
    }

    public static void Test() {
        int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 1 };
        var indexes = Enumerable.Range(0, a.Length).ToArray();
        Array.Sort(a, indexes);
    }
}