// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using welearn.net.algo.piece;
using welearn.net.easy;
using welearn.net.play.Benchmark.Algo;
using welearn.net.play.Benchmark.Algo.ExactCover;
using welearn.net.play.Benchmark.LeetCode;

// BenchmarkRunner.Run<Combinatorics>();
// BenchmarkRunner.Run<SelfCrossingBm>()
// BenchmarkRunner.Run<HeapBm>();
BenchmarkRunner.Run<SetupTeamBm>();