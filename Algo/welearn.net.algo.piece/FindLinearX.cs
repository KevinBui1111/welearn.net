namespace welearn.net.algo.piece;

public class FindLinearX {
    // find minimum x that f(x) >= minDesiredY && f(x-1) < minDesiredY
    public static (int x, int loopCnt) FindX(Func<int, double> fx, int initX, double minDesiredY) {
        var curX = initX;
        var loX = 0;
        var hiX = curX;
        var loopCnt = 0;
        while (true) {
            ++loopCnt;
            var y = fx(curX);

            if (y >= minDesiredY) {
                // decrease x;
                hiX = curX;
                curX -= (curX - loX) / 2;
                
                if (curX == hiX) return (hiX, loopCnt);
            } else {
                // increase x;
                if (hiX == curX) {
                    loX = curX;
                    hiX = curX = 2 * curX;
                } else {
                    loX = curX;
                    curX += (hiX - curX) / 2;

                    if (curX == loX) return (hiX, loopCnt);
                }
            }
        }
    }

    public static void TestFindX()
    {
        Func<int, double> fx = x => 2 * x;
        Func<int, double> fx2 = x => x * Math.Log(x);

        var resX = FindX(fx2, 1, 191);
        Console.WriteLine($"resX = {resX}");
    }
}