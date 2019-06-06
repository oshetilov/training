using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList(new Node(1));
            var tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                var number = i;
                tasks.Add(Task.Run(() => list.AddHead(new Node(number))));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(list.root);
        }
    }
}
