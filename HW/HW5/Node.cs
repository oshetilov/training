using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    public class Node
    {
        private int data;
        public Node Next { get; set; }
        public Node(int d) { data = d; }
    }
}
