using System;
using System.Collections.Generic;

namespace FibonacciBenchmark
{
    class Program
    {
        private static Dictionary<int, int> _cache = new Dictionary<int, int>();
        private static int _depth;

        static void Main(string[] args)
        {
            var num = 7;

            //var result = FibonacciRecursive(num);
            var result = FibonacciRecursiveCache(num);

            Console.WriteLine("\nPosition: {0} -> Number: {1}", num, result);
            Console.WriteLine("Depth: {0}", _depth);
        }

        private static int FibonacciRecursive(int n)
        {
            Console.WriteLine("Computing {0}", n);
            _depth++;

            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        private static int FibonacciRecursiveCache(int n)
        {
            Console.WriteLine("Computing {0}", n);
            _depth++;

            if (n == 0) return 0;
            if (n == 1) return 1;

            if (_cache.TryGetValue(n, out int value))
            {
                Console.WriteLine("Getting from cache {0}", n);

                return value;
            }

            value = FibonacciRecursiveCache(n - 1) + FibonacciRecursiveCache(n - 2);

            if(_cache.TryAdd(n, value))
            {
                Console.WriteLine("Adding to cache {0}", n);
            }

            return value;
        }
    }
}
