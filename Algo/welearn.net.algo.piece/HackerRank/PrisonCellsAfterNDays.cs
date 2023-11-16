using System.ComponentModel;

namespace welearn.net.algo.piece.HackerRank;

public static class PrisonCellsAfterNDays {
    public static int[] PrisonAfterNDays(int[] cells, int n) {
        var tmp = new int[cells.Length];
        for (var i = 0; i < n; ++i) {
            for (var j = 1; j < cells.Length - 1; ++j) {
                tmp[j] = cells[j - 1] == cells[j + 1] ? 1 : 0;
            }

            cells[0] = cells[^1] = 0;
            (cells, tmp) = (tmp, cells);
        }

        return cells;
    }
    
    public static int[] PrisonAfterNDays2(int[] cells, int n) {
        var cycles = new List<int[]>();

        for (var i = 0; i < n; ++i) {
            var tmp = new int[cells.Length];
            
            for (var j = 1; j < cells.Length - 1; ++j) {
                tmp[j] = cells[j - 1] == cells[j + 1] ? 1 : 0;
            }

            if (cycles.Count > 0 && tmp.SequenceEqual(cycles[0])) {
                var index = n % cycles.Count - 1;
                return index == -1 ? cycles[^1] : cycles[index];
            }

            cycles.Add(tmp);
            cells = tmp;
        }

        return cells;
    }
}