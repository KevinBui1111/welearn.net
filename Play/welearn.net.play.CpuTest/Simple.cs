using System.Diagnostics;
using welearn.net.easy;

namespace welearn.net.play.CpuTest; 

internal static class Simple {
    // record: bound 2e9,
    //      37.7s, core i7 - 9850H 2.6GHhz (ThinkPad P53)
    //      40.8s, core i7 - 8550U 1.8 - 4.0 GHhz (HP Probook 440 G5)
    //      34.3s, core i7 - 10850H 2.7GHz
    //
    // bound 4e9,
    //      01:16, core i7 - 9850H 2.6GHhz (ThinkPad P53)
    //      01:08, core i7 - 10850H 2.7GHhz (ThinkPad P15 Gen 1)
    //      00:55, AMD Ryzen™ 7 PRO 5850U 1.9GHz - 4.4GHz
    //      00:53, AMD Ryzen™ 7 PRO 6850H 3.2GHz - 4.7GHz
    //      00:52, AMD Ryzen™ 7 PRO 6850U 2.7GHz - 4.7GHz (ThinkPad T14 gen 3)
    //      00:52, core i5 - 1335U up to 4.6GHz (ThinkBook 15 Gen 5)
    //      00:47, AMD Ryzen™ 7 PRO 7840HS 3.8GHz - 5.1GHz (ThinkPad P16v Gen 1)
    //      00:46, core Ultra 7 165U 1.7GHz - 4.9GHz (ThinkPad T16 Gen 3)
    //     	00:46, core i7 - 12800H up to 2.4GHz (ThinkPad P15v Gen 3)
    public static long TotalSin(long bound) {
        long total = 0;
        for (long i = 0; i < bound; i++)
            total += (int)(Math.Sin(i) * 1000);

        return total;
    }

    // record: bound 2e9, 07.62s, core i7 - 9850H 2.6GHhz (ThinkPad P53)
    public static long TotalSinParallel(long bound) {
        long total = 0;
        Parallel.For<long>(0, bound,
            () => 0,
            (i, _, subTotal) => subTotal + (int)(Math.Sin(i) * 1000),
            finalTotal => Interlocked.Add(ref total, finalTotal)
        );

        return total;
    }

    // record: bound 2e9,
    //      06.09s, core i7 - 9850H 2.6GHhz (ThinkPad P53)
    //      10.25s, core i7 - 8550U 1.8 - 4.0 GHhz (HP Probook 440 G5)
    //      04.91s, core i7 - 10850H 2.7GHz (ThinkPad P15 Gen 1)
    //
    //         bound 4e9,
    //      13.00s, core i7 - 9850H 2.6GHhz (ThinkPad P53)
    //      10.48s, AMD Ryzen™ 7 PRO 5850U 1.9GHz - 4.4GHz
    //      09.77s, core i7 - 10850H 2.7GHhz (ThinkPad P15 Gen 1)
    //      09.18s, AMD Ryzen™ 7 PRO 6850U 2.7GHz - 4.7GHz (ThinkPad T14 gen 3)
    //      08.88s, core i5 - 1335U up to 4.6GHz (ThinkBook 15 Gen 5)
    //      08.74, core Ultra 7 165U 1.7GHz - 4.9GHz (ThinkPad T16 Gen 3)
    //      06.44s, AMD Ryzen™ 7 PRO 6850H 3.2GHz - 4.7GHz
    //     	05.63s, core i7 - 12800H up to 2.4GHz (ThinkPad P15v Gen 3)
    //      05.01s, AMD Ryzen™ 7 PRO 7840HS 3.8GHz - 5.1GHz (ThinkPad P16v Gen 1)
    public static long totalSinParallel_Task(long bound) {
        int threadCount = Environment.ProcessorCount;
        var parts = ListUtil.Distribute(0, bound, threadCount);
        var tasks = new List<Task<long>>();

        foreach (var part in parts) {
            var t = Task.Run(() => SubTotalFunc(part.from, part.to));
            tasks.Add(t);
        }
        Task.WaitAll(tasks.ToArray());

        return tasks.Sum(t => t.Result);

        long SubTotalFunc(long from, long subBound) {
            long subTotal = 0;
            for (long i = from; i < subBound; i++)
                subTotal += (int)(Math.Sin(i) * 1000);
            return subTotal;
        }
    }

    public static void Test() {
        long bound = 4_000_000_000;

        Console.WriteLine("====== CPU Test - Total Sin =========");
        Console.Write("Input bound (or leave for default 4 billions): ");
        var input = Console.ReadLine();
        if (!String.IsNullOrEmpty(input)) bound = long.Parse(input);

        Console.WriteLine("-- sequential (one thread) --");
        var timer = Stopwatch.StartNew();
        long total = Simple.TotalSin(bound);
        Console.WriteLine($"total: {total:n0}, elapsed: {timer.Elapsed}");

        Console.WriteLine("-- parallel (multithread) --");
        timer.Restart();
        total = Simple.totalSinParallel_Task(bound);
        Console.WriteLine($"total: {total:n0}, elapsed: {timer.Elapsed}");
    }
}