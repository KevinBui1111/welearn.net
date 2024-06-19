namespace welearn.net.algo.piece.Matrix;

public class Multiplication {
    public static int[,] Multiply(int[,] matrixA, int[,] matrixB) {
        var resRow = matrixA.GetLength(0);
        var resCol = matrixB.GetLength(1);
        var resMatrix = new int[resRow, resCol];

        for (var r = 0; r < resRow; ++r)
            for (var c = 0; c < resCol; ++c)
                resMatrix[r, c] = CalcRc(r, c);

        return resMatrix;
        
        int CalcRc(int r, int c) {
            var res = 0;
            for (var i = 0; i < resCol; i++)
                res += matrixA[r, i] * matrixB[i, c];

            return res;
        }
    }
    
    public static int[,] Multiply_Parallel(int[,] matrixA, int[,] matrixB) {
        var resRow = matrixA.GetLength(0);
        var resCol = matrixB.GetLength(1);
        var resMatrix = new int[resRow, resCol];

        Parallel.For(0, resRow * resCol, i => {
            var (r, c) = (i / resCol, i % resCol);
            resMatrix[r, c] = CalcRc(r, c);
        });

        return resMatrix;
        
        int CalcRc(int r, int c) {
            var res = 0;
            for (var i = 0; i < resCol; i++)
                res += matrixA[r, i] * matrixB[i, c];

            return res;
        }
    }
}