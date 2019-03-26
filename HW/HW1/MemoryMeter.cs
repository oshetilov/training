using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class MemoryMeter
    {

        public long GetAvailableMemoryAllocate()
        {
            var performance = new PerformanceCounter("Memory", "Available Bytes");
            return Convert.ToInt64( performance.NextValue());
        }

        public long GetMaxSingleBlockSize()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        
            var startMemory = GC.GetTotalMemory(false);
            long maxBlockMemory = 0;

            var list = new List<object>();
            try
            {
                while(true)
                {
                    list.Add(new byte[1024 * 1024]);
                }
            }
            catch (OutOfMemoryException)
            {
                maxBlockMemory = GC.GetTotalMemory(false)  - startMemory;
            }

            return maxBlockMemory;
        }

    }
}
