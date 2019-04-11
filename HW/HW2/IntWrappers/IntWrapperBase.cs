using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.IntWrappers
{
    public abstract class IntWrapperBase
    {
        public int IntValue { get; }

        public IntWrapperBase(int value)
        {
            IntValue = value;
        }

        public override abstract int GetHashCode();

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType() && this.GetHashCode() == obj.GetHashCode() )
            {
                var wrapper = (IntWrapperBase)obj;

                return wrapper.IntValue == this.IntValue;
            }
            return false;
        }

    }
}
