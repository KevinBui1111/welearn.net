using welearn.net.easy;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace welearn.net.algo.prime; 

/// <summary>
/// Move from ConsoleApp project
/// Build since 2022-02-09 -> 2022-02-22
/// Fix memory: 2023-02-08
/// </summary>
public static class Prime
{
    public static long nth_prime(int n)
    {
        var primes = new List<int>() { 2 };
        var number = 1;

        while (primes.Count < n)
        {
            number += 2;
            var success = true; // to check if found prime
            var sqrt = (int)Math.Sqrt(number);

            foreach (var b in primes) {
                if (b > sqrt)
                    break;
                if (number % b == 0)
                {
                    success = false;
                    break;
                }
            }

            if (success) primes.Add(number);
        }

        return primes[^1];
    }

    public static List<int> SieveEratosthenes(int n)
    {
        var sieve = new BitArray(n, true);
        var slf = new int[n + 1];
        for (int i = 0; i < n; ++i) slf[i] = i;
            
        var primes = new List<int>();
        var sqrtMax = (int)Math.Ceiling(Math.Sqrt(n));

        for (var p = 2; p < sqrtMax; ++p)
            if (sieve[p])
            {
                primes.Add(p);

                var inc = p == 2 ? 1 : 2;
                for (var mul = p; mul * p < n; mul += inc)
                    if (slf[mul] >= p)
                    {
                        sieve[mul * p] = false;
                        slf[mul * p] = p;
                    }
            }

        for (int p = sqrtMax; p < n; ++p)
            if (sieve[p])
                primes.Add(p);

        return primes;
    }

    // find prime in range [from..N), base on primes in range [2..from)
    private static List<long> sieve_era_part(List<long> primes, long from, long N)
    {
        // assume primes is the list of prime number from 2 to 'from' param
        var sievePart = new BitArray((int)(N - from), true);
        //sieve_part.SetAll(true);

        int limit = (int)Math.Ceiling(Math.Sqrt(N));
        // [2..p] can find prime < (p+2)^2
        if (primes[^1] < limit - 2)
        {
            Console.Error.WriteLine($"May be enough base primes to find up to {N:n0}");
            //return null;
        }

        for (int i = 0; i < primes.Count && primes[i] < limit; ++i)
        {
            var p = primes[i];

            // let cross = [];
            int inc = p > 2 ? 2 : 1;
            var mul = (from + p - 1) / p;
            if (p > 2 && (mul & 1) == 0) ++mul; // odd, not even
            if (mul < p) mul = p;
            for (; mul * p < N; mul += inc)
                sievePart[(int)(mul * p - from)] = false;
        }

        var newPrimes = new List<long>();
        for (long i = Math.Max(from, 2); i < N; ++i)
            if (sievePart[(int)(i - from)])
                newPrimes.Add(i);

        return newPrimes;
    }

    // return all primes [2..max)
    public static List<int> Sieve22Max(int max)
    {
        var sievePart = new BitArray(max, true); // default all prime
        var spdPart = new int[max];
        Console.WriteLine($"init_space_part, size {max:n0}");

        var prime = new List<int>();

        for (var i = 2; i < max; ++i)
        {
            if (sievePart[i])
            {
                prime.Add(i);
                spdPart[i] = i;
            }

            foreach(var p in prime)
            {
                if (p > spdPart[i] || p * i >= max) break;

                sievePart[p * i] = false;
                spdPart[p * i] = p;
            }
        }

        return prime;
    }

    // record: 1e9 in 5.97s, core i7 - 9850H 2.6GHhz
    public static List<long> Sieve22Max_Naive(int max)
    {
        var primes = new List<long>();
        var sieve = new BitArray(max, true); // default all prime

        var sqrtMax = (int)Math.Ceiling(Math.Sqrt(max));

        for (var p = 2; p < sqrtMax; ++p)
        {
            if (sieve[p])
            {
                primes.Add(p);

                var inc = p == 2 ? p : 2 * p;
                for (long mul = p * p; mul < max; mul += inc)
                    // cross out multiple of prime p
                    sieve[(int)mul] = false;
            }
        }

        for (int p = sqrtMax; p < max; ++p)
            if (sieve[p])
                primes.Add(p);

        return primes;
    }

    // find nth prime number, use less memory,
    // extend range to MAX_PART size each loop
    // find 50_847_534    nth prime in 5.5s, core i7 - 9850H 2.6GHhz
    // find 1_000_000_000 nth prime in
    //      2:40.65, core i7 - 8550U 1.8 - 4.0 GHhz
    //      1:56, core i7 - 9850H 2.6GHhz
    //      1:26, core i7 - 10850H 2.7GHz
    //      1:14, AMD Ryzen™ 7 PRO 5850U 1.9GHz - 4.4GHz
    //      1:14, AMD Ryzen™ 7 PRO 6850H 3.2GHz - 4.7GHz
    //      1:11, AMD Ryzen™ 7 PRO 6850U 2.7GHz - 4.7GHz
    //      1:16, AMD Ryzen™ 7 PRO 7840HS 3.8GHz - 5.1GHz
    public static long NthPrime(int n)
    {
        // find prime up to MAX
        var MAX_PART = 1_000_000;
        var max = 50_000L;
        var basePrimes = Sieve22Max_Naive((int)max);
        var newPrimes = basePrimes;

        var pCount = basePrimes.Count;
        while (pCount < n)
        {
            // sieve for next segment
            newPrimes = sieve_era_part(basePrimes, max, max + MAX_PART);
            max += MAX_PART;

            if (basePrimes[^1] < 200_000) {
                // extend primes
                basePrimes.AddRange(newPrimes);
            }

            pCount += newPrimes.Count;
        }

        // Console.WriteLine($"Range to: {max:n0}");

        return newPrimes[^(pCount - n + 1)];
    }


    /// <param name="bound">up to (2^31 - 1) ^ 2 </param>
    /// <returns>the greatest prime less than bound</returns>
    public static long LastPrime(long bound) {
        int MAX_PART = 1_000_000;
        // get max prime to sieve range to bound
        var max = (long)Math.Ceiling(Math.Sqrt(bound));
        // find prime less than prime_bound
        var primes = Sieve22Max_Naive((int)max);

        var newPrimes = new List<long>();
        max = bound;
        while (newPrimes.Count == 0) {
            max -= MAX_PART;
            newPrimes = sieve_era_part(primes, max, max + MAX_PART);
        }

        return newPrimes[^1];
    }

    /// <summary>
    /// record: 23e9 in 1:44, core i7 - 9850H 2.6GHhz
    ///                 1:57, core i7 - 8550U 1.8 - 4.0 GHhz
    ///                 1:23, core i7 - 10850H 2.7GHz
    ///                 1:15, AMD Ryzen™ 7 PRO 5850U 1.9GHz - 4.4GHz
    ///                 1:12, AMD Ryzen™ 7 PRO 6850H 3.2GHz - 4.7GHz
    ///                 1:10, AMD Ryzen™ 7 PRO 6850U 2.7GHz - 4.7GHz
    ///                 1:21, AMD Ryzen™ 7 PRO 7840HS 3.8GHz - 5.1GHz
    /// </summary>
    public static (long count, long last) HowMany(long bound) {
        int MAX_PART = 1_000_000;
        // get max prime to sieve range to bound
        var to = (long)Math.Ceiling(Math.Sqrt(bound));
        // find prime less than prime_bound
        var primes = Sieve22Max_Naive((int)to);
        var res = (count: (long)primes.Count, last: primes[^1]);

        var from = to;
        while (from < bound) {
            to = Math.Min(bound, from + MAX_PART);
            var newPrimes = sieve_era_part(primes, from, to);

            if (newPrimes.Count > 0) {
                res.count += newPrimes.Count;
                res.last = newPrimes[^1];
            }

            from = to;
        }

        return res;
    }


    /// <summary>
    /// record: 23e9 in 25.7s, core i7 - 9850H 2.6GHhz
    ///                 50.4, core i7 - 8550U 1.8 - 4.0 GHhz
    ///                 17.8, core i7 - 10850H 2.7GHz
    ///                 19.0, AMD Ryzen™ 7 PRO 5850U 1.9GHz - 4.4GHz
    ///                 12.4, AMD Ryzen™ 7 PRO 6850H 3.2GHz - 4.7GHz
    ///                 16.4, AMD Ryzen™ 7 PRO 6850U 2.7GHz - 4.7GHz
    ///                 10.6, AMD Ryzen™ 7 PRO 7840HS 3.8GHz - 5.1GHz
    /// </summary>
    public static (long count, long last) HowManyParallel(long bound) {
        int MAX_PART = 1_000_000;
        // get max prime to sieve range to bound
        var to = (long)Math.Ceiling(Math.Sqrt(bound));
        // find prime less than prime_bound
        var primes = Sieve22Max_Naive((int)to);
        var res = (count: (long)primes.Count, last: primes[^1]);

        // init space
        //sieve_part = new BitArray(MAX_PART, true);
        var bc = new BlockingCollection<(long count, long last)>();
        long from = to;
        long segCount = (bound - from - 1) / MAX_PART + 1;
        Parallel.For(0, segCount + 1, i => {
            if (i == segCount) {
                long segCompleteCount = 0;
                foreach (var resSeg in bc.GetConsumingEnumerable()) {
                    ++segCompleteCount;

                    res.count += resSeg.count;
                    if (resSeg.last > res.last) res.last = resSeg.last;

                    if (segCompleteCount == segCount) bc.CompleteAdding();
                }
            } else {
                long segBound = Math.Min(bound, from + (i + 1) * MAX_PART);
                var new_primes = sieve_era_part(primes, from + i * MAX_PART, segBound);

                bc.Add((new_primes.Count, new_primes.Count == 0 ? 0 : new_primes[^1]));

                //if (new_primes.Count > 0) {
                //    lock (primes) {
                //        res.count += new_primes.Count;
                //        if (new_primes[^1] > res.last) res.last = new_primes[^1];
                //    }
                //}
            }
        });

        return res;
    }
    /// <summary>
    /// worse than howManyParallel
    /// </summary>
    public static (long count, long last) howManyParallel2(long bound) {
        int MAX_PART = 1_000_000;
        // get max prime to sieve range to bound
        var from = (long)Math.Ceiling(Math.Sqrt(bound));
        // find prime less than prime_bound
        var primes = Sieve22Max_Naive((int)from);
        var res = (count: (long)primes.Count, last: primes[^1]);

        var segments = ListUtil.Distribute(from, bound, 12);

        void seive_segment((long from, long to) seg) {
            var timer = Stopwatch.StartNew();
            var resSeg = (count: 0L, last: 0L);

            while (seg.from < seg.to) {
                long toPart = Math.Min(seg.to, seg.from + MAX_PART);
                var new_primes = sieve_era_part(primes, seg.from, toPart);

                if (new_primes.Count > 0) {
                    resSeg.count += new_primes.Count;
                    resSeg.last = new_primes[^1];
                }

                seg.from = toPart;
            }

            //lock (primes) {
            //    res.count += resSeg.count;
            //    if (resSeg.last > res.last) res.last = resSeg.last;
            //}

            //Console.WriteLine($"seg {seg}, elapsed: {timer.Elapsed}");
        };

        var listTask = new List<Task>();
        foreach (var seg in segments) {
            var t = Task.Run(() => seive_segment(seg));
            listTask.Add(t);
        }
        Task.WaitAll(listTask.ToArray());

        return res;
    }
}