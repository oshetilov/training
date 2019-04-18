using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.VisualBasic.FileIO;

namespace HW3
{
    public class Program
    {
        static void Main(string[] args)
        {
             BenchmarkRunner.Run<BenchmarkMeter>();

            /* var firstPart = ReadCSV("./Barcelona1.csv");
             var secondPart = ReadCSV("./Barcelona2.csv");

             var union = firstPart.Union(secondPart);
             var unionAll = firstPart.UnionAll(secondPart);

             Console.ReadLine(); */
        }

        public static List<Apartment> ReadCSV(string path)
        {
            var apartments = new List<Apartment>();

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();
                while (!csvParser.EndOfData)
                {
                    string[] items = csvParser.ReadFields();

                    if(items.Length != 7)
                    {
                        continue;
                    }

                    int id;

                    if (!int.TryParse(items[0], out id))
                    {
                        var chanks = items[0].Split( '/' );

                        id = int.Parse(string.Concat(chanks[chanks.Length - 1].Where(x=> char.IsDigit(x))));
                    }

                    var name = items[1];
                    var zipCode = items[2];
                    var smartLocation = items[3];
                    var country = items[4];
                    var latitude = float.Parse(items[5]);
                    var longitude = float.Parse(items[6]);

                    apartments.Add(new Apartment(id, name, zipCode, smartLocation, country, latitude, longitude));
                }
            }
            return apartments;
        }
    }


    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class BenchmarkMeter
    {

        private readonly List<Apartment> firstPart = Program.ReadCSV("./Barcelona1.csv");
        private readonly List<Apartment> secondPart = Program.ReadCSV("./Barcelona2.csv");

        [Benchmark]
        public void TestWrapper1() => ApartmentExtensions.Union(firstPart, secondPart);
        [Benchmark]
        public void TestWrapper2() => ApartmentExtensions.UnionAll(firstPart, secondPart);

    }
}
