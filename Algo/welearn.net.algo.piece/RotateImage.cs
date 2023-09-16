namespace welearn.net.algo.piece;

public static class RotateImage {
    public static void Rotate90Clockwise(int[][] matrix) {
        var size = matrix.Length;
        var round = size / 2;
        int tmp;
        for (var r = 0; r < round; ++r) {
            for (var c = r; c < size - 1 - r; ++c) {
                /*
                 * r, c -> c, size - 1 - r
                 * -> size - 1 - r, size - 1 - c
                 * -> size - 1 - c, size - 1 - (size - 1 - r)
                 *  = size - 1 - c, r
                 * -> r, size - 1 - (size - 1 - c)
                 *  = r, c
                 */
                // (
                //     matrix[r][c],
                //     matrix[c][size - 1 - r],
                //     matrix[size - 1 - r][size - 1 - c],
                //     matrix[size - 1 - c][r]
                // ) = (
                //     matrix[size - 1 - c][r],
                //     matrix[r][c],
                //     matrix[c][size - 1 - r],
                //     matrix[size - 1 - r][size - 1 - c]
                // );

                tmp = matrix[r][c];
                matrix[r][c] = matrix[size - 1 - c][r];
                matrix[size - 1 - c][r] = matrix[size - 1 - r][size - 1 - c];
                matrix[size - 1 - r][size - 1 - c] = matrix[c][size - 1 - r];
                matrix[c][size - 1 - r] = tmp;
            }
        }
    }
}