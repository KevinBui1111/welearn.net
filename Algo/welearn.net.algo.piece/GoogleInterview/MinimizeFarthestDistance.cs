namespace welearn.net.algo.piece.GoogleInterview;

public static class MinimizeFarthestDistance {
    public static int FindIdealBlock(string[][] blocks, string[] needs) {
        var needDistance = new int[blocks.Length][];
 
        for (var i = 0; i < blocks.Length; ++i) {
            for (var n = 0; n < needs.Length; ++n) {
                needDistance[i] = new int[needs.Length];
                needDistance[i][n] = blocks[i].Contains(needs[n])
                    ? 0
                    : 0 < i
                        ? needDistance[i - 1][n] + 1
                        : int.MaxValue / 2;
            }
        }
        
        for (var i = blocks.Length - 1; i >= 0; --i) {
            for (var n = 0; n < needs.Length; ++n) {
                var d = blocks[i].Contains(needs[n])
                    ? 0
                    : i < blocks.Length - 1
                        ? needDistance[i + 1][n] + 1
                        : int.MaxValue / 2;
                if (d < needDistance[i][n]) needDistance[i][n] = d;
            }
        }

        var idealBlock = needDistance
            .Select((b, i) => new { i, max = b.Max() })
            .MinBy(b => b.max)
            ?.i;
        
        return idealBlock ?? -1;
    }
}