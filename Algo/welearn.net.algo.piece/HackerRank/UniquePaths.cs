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

    public static int HowManyPathIII(int[][] grid) {
        var totalBlank = 0;
        var start = (x: -1, y: -1);
        for (var x = 0; x < grid.Length; ++x) {
            for (var y = 0; y < grid[0].Length; ++y) {
                if (grid[x][y] >= 0) ++totalBlank;
                if (grid[x][y] == 1) start = (x, y);
            }
        }

        int cntWalk = 0, found = 0;
        Go(start.x, start.y);
        
        return found;

        void Go(int x, int y) {
            ++cntWalk;
            if (grid[x][y] == 2) {
                if (cntWalk == totalBlank) {
                    ++found;
                }
            }
            else {
                grid[x][y] = -2;
                
                if (CanGo(x + 1, y)) Go(x + 1, y);
                if (CanGo(x - 1, y)) Go(x - 1, y);
                if (CanGo(x, y + 1)) Go(x, y + 1);
                if (CanGo(x, y - 1)) Go(x, y - 1);
                
                grid[x][y] = 0;
            }
            --cntWalk;
        }

        bool CanGo(int x, int y) =>
            x >= 0 && y >= 0 && x < grid.Length && y < grid[0].Length &&
            (grid[x][y] == 0 || grid[x][y] == 2);
    }
}