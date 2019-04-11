using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.IntWrappers
{
    public class IntWrapper2 : IntWrapperBase
    {

        public IntWrapper2(int value) : base(value) {}

        public override int GetHashCode()
        {
            return ((IntValue >> 16) ^ IntValue) * 0x45d9f3b;
        }
    }
}
