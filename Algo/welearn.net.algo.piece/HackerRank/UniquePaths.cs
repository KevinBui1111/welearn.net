namespace welearn.net.algo.piece.HackerRank;

public static class UniquePaths {
    public static int HowManyPath(int m, int n) {
        var matrix = new int[m, n];
        // first row = 1
        for (var i = 0; i < m; ++i) {
            matrix[i, 0] = 1;
        }

        // first column = 1
        for (var i = 0; i < n; ++i) {
            matrix[0, i] = 1;
        }

        for (var c = 1; c < m; ++c) {
            for (var r = 1; r < n; ++r) {
                matrix[c, r] = matrix[c - 1, r] + matrix[c, r - 1];
            }
        }

        return matrix[m - 1, n - 1];
    }
}