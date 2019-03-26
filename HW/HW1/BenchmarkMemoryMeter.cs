using System;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW1
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class BenchmarkMemoryMeter
    {
        private readonly MemoryMeter memoryMeter = new MemoryMeter();

        [Benchmark]
        public long GetAvailableMemoryAllocate() => memoryMeter.GetAvailableMemoryAllocate();

        [Benchmark]
        public long GetMaxSingleBlockSize() => memoryMeter.GetMaxSingleBlockSize();
    }
}
