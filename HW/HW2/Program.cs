using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using HW2.IntWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkMeter>();
        }

        public static void TestWrapper1()
        {
            var rand = new Random();
            Container<IntWrapper1, int> container = new Container<IntWrapper1, int>();

            for (int i=0; i<10000; i++)
            {
                var value = rand.Next(0, 10000);
                container.Add(new IntWrapper1(value), value);
            }
        }

        public static void TestWrapper2()
        {
            var rand = new Random();
            Container<IntWrapper1, int> container = new Container<IntWrapper1, int>();

            for (int i = 0; i < 10000; i++)
            {
                var value = rand.Next(0, 10000);
                container.Add(new IntWrapper1(value), value);
            }
        }

        public static void TestWrapper3()
        {
            var rand = new Random();
            Container<IntWrapper3, int> container = new Container<IntWrapper3, int>();

            for (int i = 0; i < 10000; i++)
            {
                var value = rand.Next(0, 10000);
                container.Add(new IntWrapper3(value), value);
            }
        }
    }

    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class BenchmarkMeter
    {
        [Benchmark]
        public void TestWrapper1() => Program.TestWrapper1();
        [Benchmark]
        public void TestWrapper2() => Program.TestWrapper2();
        [Benchmark]
        public void TestWrapper3() => Program.TestWrapper3();

    }
}


