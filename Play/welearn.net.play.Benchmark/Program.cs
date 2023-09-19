// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using welearn.net.play.Benchmark.Algo;

var summary = BenchmarkRunner.Run<Combinatorics>();