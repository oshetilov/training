using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.IntWrappers
{
    public class IntWrapper3 : IntWrapperBase
    {

        public IntWrapper3(int value) : base(value) {}

        public override int GetHashCode()
        {
            return IntValue;
        }
    }
}
