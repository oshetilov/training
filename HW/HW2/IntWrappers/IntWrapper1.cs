using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.IntWrappers
{
    public class IntWrapper1 : IntWrapperBase
    {

        public IntWrapper1(int value) : base(value) {}

        public override int GetHashCode()
        {
            return 101 * ((IntValue >> 24) + 101 * ((IntValue >> 16) + 101 * (IntValue >> 8))) + IntValue;
        }
    }
}
