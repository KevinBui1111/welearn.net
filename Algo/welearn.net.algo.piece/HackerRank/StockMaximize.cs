namespace welearn.net.algo.piece.HackerRank;

public class StockMaximize {
    // move from ConsoleCore project, 2020-10-29 13:24
    // https://www.hackerrank.com/challenges/stockmax/problem
    public static long StockMax_(List<int> prices) {
        if (prices.Count == 0) return 0;
        // find tip
        int iTip = prices.IndexOf(prices.Max());
        long profit = iTip * (long)prices[iTip] - prices.Take(iTip).Sum(p => (long)p);
        profit += StockMax_(prices.Skip(iTip + 1).ToList());
        return profit;
    }

    public static long StockMax(List<int> prices) {
        // find tip, partition
        int last_tip = 0;
        var tips = new (long p, int i)[prices.Count];
        for (int i = 0; i < prices.Count; ++i) {
            while (last_tip >= 0 && tips[last_tip].p <= prices[i]) {
                --last_tip;
            }

            tips[++last_tip] = (prices[i], i);
            Console.WriteLine(tips[last_tip]);
        }

        // calc
        long profit = 0;
        int prev_tip = 0;
        for (int i = 0; i <= last_tip; ++i) {
            var tip = tips[i];
            profit += (tip.i - prev_tip) * (long)prices[tip.i] -
                      prices.Skip(prev_tip).Take(tip.i - prev_tip).Sum(p => (long)p);
            prev_tip = tip.i + 1;
        }

        return profit;
    }
}