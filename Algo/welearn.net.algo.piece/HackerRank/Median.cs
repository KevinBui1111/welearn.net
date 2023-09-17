namespace welearn.net.algo.piece.HackerRank;

public class Median {
    public static int FindMedian(List<int> arr) {
        arr.Sort();
        return arr.Count % 2 == 0
            ? (arr[arr.Count / 2] + arr[arr.Count / 2 + 1]) / 2
            : arr[arr.Count / 2];
    }

    public static double FindMedian(int[] arr) {
        Array.Sort(arr);
        return FindMedianSortedArray(arr);
    }

    public static double FindMedianSortedArray(int[] arr) =>
        arr.Length % 2 == 0
            ? (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2.0
            : arr[arr.Length / 2];

    public double FindMedianSortedArrays1(int[] nums1, int[] nums2) {
        var num = new int[nums1.Length + nums2.Length];
        nums1.CopyTo(num, 0);
        nums2.CopyTo(num, nums1.Length);

        return FindMedian(num);
    }

    public static int[] MergeSortedArrays(int[] nums1, int[] nums2) {
        var arr = new int[nums1.Length + nums2.Length];
        
        int idx1 = 0, idx2 = 0, idx = 0;
        while (idx1 < nums1.Length && idx2 < nums2.Length) {
            arr[idx++] = nums1[idx1] < nums2[idx2]
                ? nums1[idx1++]
                : nums2[idx2++];
        }

        int[] num;
        if (idx1 == nums1.Length) {
            idx1 = idx2;
            num = nums2;
        }
        else {
            num = nums1;
        }

        while (idx1 < num.Length) {
            arr[idx++] = num[idx1++];
        }

        return arr;
    }

    public double FindMedianSortedArrays2(int[] nums1, int[] nums2) {
        var num = MergeSortedArrays(nums1, nums2);
        return FindMedianSortedArray(num);
    }
}