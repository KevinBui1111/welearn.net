// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using welearn.net.play.Benchmark.Algo;
using welearn.net.play.Benchmark.LeetCode;

// var summary = BenchmarkRunner.Run<Combinatorics>();
var summary = BenchmarkRunner.Run<SelfCrossingBm>();