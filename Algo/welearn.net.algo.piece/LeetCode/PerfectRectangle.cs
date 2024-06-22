namespace welearn.net.algo.piece.LeetCode;

//https://leetcode.com/problems/perfect-rectangle/solutions/
public class PerfectRectangle {
    public bool IsRectangleCover(int[][] rectangles) {
        (int left, int bottom, int right, int top) boundary = (int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
        var allRectArea = 0;
        foreach (var r in rectangles) {
            if (r[0] < boundary.left) boundary.left = r[0];
            if (r[1] < boundary.bottom) boundary.bottom = r[1];
            if (boundary.right < r[2]) boundary.right = r[2];
            if (boundary.top < r[3]) boundary.top = r[3];

            allRectArea += (r[2] - r[0]) * (r[3] - r[1]);
        }

        var boundaryArea = (boundary.right - boundary.left) * (boundary.top - boundary.bottom);
        if (allRectArea != boundaryArea) return false;

        for(var i = 0; i < rectangles.Length; ++i)
            for(var j = i + 1; j < rectangles.Length; ++j)
                if (IsOverlap(rectangles[i], rectangles[j]))
                    return false;
        
        return true;
    }

    private bool IsOverlap(int[] rect1, int[] rect2) {
        if (rect2[0] < rect1[0])
            (rect1, rect2) = (rect2, rect1);
        if (rect1[2] <= rect2[0]) return false;

        if (rect2[1] < rect1[1])
            (rect1, rect2) = (rect2, rect1);

        return rect2[1] < rect1[3];
    }
    
    // refer solution from leetcode, O(n)
    public bool IsRectangleCover2(int[][] rectangles) {
        var mapCorners = new HashSet<(int, int)>();
        (int left, int bottom, int right, int top) boundary = (int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
        foreach (var r in rectangles) {
            if (r[0] < boundary.left) boundary.left = r[0];
            if (r[1] < boundary.bottom) boundary.bottom = r[1];
            if (boundary.right < r[2]) boundary.right = r[2];
            if (boundary.top < r[3]) boundary.top = r[3];

            if (!mapCorners.Add((r[0], r[1]))) mapCorners.Remove((r[0], r[1]));
            if (!mapCorners.Add((r[0], r[3]))) mapCorners.Remove((r[0], r[3]));
            if (!mapCorners.Add((r[2], r[1]))) mapCorners.Remove((r[2], r[1]));
            if (!mapCorners.Add((r[2], r[3]))) mapCorners.Remove((r[2], r[3]));
        }
        
        return mapCorners.Count == 4;
    }


    public static void Test() {
        int[][] rects = [[1, 1, 3, 3], [3, 1, 4, 2], [3, 2, 4, 4], [1, 3, 2, 4], [2, 3, 3, 4]];
        new PerfectRectangle().IsRectangleCover2(rects);
    }
}