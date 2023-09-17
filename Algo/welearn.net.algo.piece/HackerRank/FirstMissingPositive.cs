namespace welearn.net.algo.piece.HackerRank;

public class FirstMissingPositive {
    // https://leetcode.com/problems/first-missing-positive/description/
    public int Solve(int[] nums) {
        Arrange(nums);
        for (var i = 0; i < nums.Length; ++i) {
            if (nums[i] != i + 1)
                return i + 1;
        }

        return nums.Length + 1;
    }

    public static void Arrange(int[] nums) {
        for (var i = 0; i < nums.Length;) {
            if (nums[i] > 0 && nums[i] <= nums.Length &&
                nums[i] != nums[nums[i] - 1]
               ) {
                (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
            }
            else {
                ++i;
            }
        }
    }

    //https://leetcode.com/problems/first-missing-positive/discuss/17214/Java-simple-solution-with-documentation
    public int FirstMissingPositive2(int[] nums) {
        var n = nums.Length;

        // 1. mark numbers (num < 0) and (num > n) with a special marker number (n+1) 
        // (we can ignore those because if all number are > n then we'll simply return 1)
        for (var i = 0; i < n; i++) {
            if (nums[i] <= 0 || nums[i] > n) {
                nums[i] = n + 1;
            }
        }
        // note: all number in the array are now positive, and on the range 1..n+1

        // 2. mark each cell appearing in the array, by converting the index for that number to negative
        for (var i = 0; i < n; i++) {
            var num = Math.Abs(nums[i]);
            if (num > n) {
                continue;
            }

            num--; // -1 for zero index based array (so the number 1 will be at pos 0)
            if (nums[num] > 0) {
                // prevents double negative operations
                nums[num] = -1 * nums[num];
            }
        }

        // 3. find the first cell which isn't negative (doesn't appear in the array)
        for (var i = 0; i < n; i++) {
            if (nums[i] >= 0) {
                return i + 1;
            }
        }

        // 4. no positive numbers were found, which means the array contains all numbers 1..n
        return n + 1;
    }
}