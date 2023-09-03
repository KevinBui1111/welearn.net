// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using welearn.net.algo.prime;
using welearn.net.play.CpuTest;

/*
  Move from ConsoleApp project
  Build since 2022-02-24
*/

var timer = new Stopwatch();
long prime;
long bound;

Console.WriteLine("======NthPrime=====");
int n = 1_000_000_000;
timer.Restart();
prime = Prime.NthPrime(n);
Console.WriteLine($"Prime nth {n:n0} is: {prime:n0}, elapsed: {timer.Elapsed}");

(long count, long last) primeHowMany;
bound = 23_000_000_000; // expect count: 1,008,309,544, lastPrime: 22,999,999,987
Console.WriteLine("=======howMany=======");
timer.Restart();
primeHowMany = Prime.HowMany(bound);
Console.WriteLine($"bound: {bound:n0}, count: {primeHowMany.count:n0}, lastPrime: {primeHowMany.last:n0}, elapsed: {timer.Elapsed}");

Console.WriteLine("=======howManyParallel=======");
timer.Restart();
primeHowMany = Prime.HowManyParallel(bound);
Console.WriteLine($"bound: {bound:n0}, count: {primeHowMany.count:n0}, lastPrime: {primeHowMany.last:n0}, elapsed: {timer.Elapsed}");

Simple.Test();