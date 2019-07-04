using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FibonacciBenchmark
{
    [CoreJob]
    [MemoryDiagnoser]
    public class FibonacciBenchmark
    {
        private Dictionary<int, int> _cache = new Dictionary<int, int>();
        private readonly int _target = 30;

        [Benchmark]
        public int FibNoMemoization() => FibonacciRecursive(_target);

        [Benchmark]
        public int FibMemoization() => FibonacciRecursiveCache(_target);

        private int FibonacciRecursive(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        private int FibonacciRecursiveCache(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (_cache.TryGetValue(n, out int value))
            {
                return value;
            }

            value = FibonacciRecursiveCache(n - 1) + FibonacciRecursiveCache(n - 2);

            _cache.TryAdd(n, value);

            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FibonacciBenchmark>();
        }
    }
}
