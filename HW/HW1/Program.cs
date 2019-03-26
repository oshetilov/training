using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;
using System.Globalization;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            var memoryMeter = new MemoryMeter();

            var availableMemory = memoryMeter.GetAvailableMemoryAllocate();
            var maxSingleBlockSize = memoryMeter.GetMaxSingleBlockSize();

            Console.WriteLine($"Available Memory {availableMemory/1024/1024} MB");
            Console.WriteLine($"Max Single Block Size {maxSingleBlockSize / 1024 / 1024} MB");

            var summary = BenchmarkRunner.Run<BenchmarkMemoryMeter>();
        }


    }
}
