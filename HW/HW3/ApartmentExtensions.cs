using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public static class ApartmentExtensions
    {
        public static IEnumerable<Apartment> Union(this IEnumerable<Apartment> first, IEnumerable<Apartment> second)
        {
            return Enumerable.Concat(first, second).ToArray();
        }

        public static IEnumerable<Apartment> UnionAll(this IEnumerable<Apartment> first, IEnumerable<Apartment> second)
        {
            HashSet<Apartment> apartments = new HashSet<Apartment>();

            foreach (Apartment item in Enumerable.Concat(first, second))
            {
                apartments.Add(item);
            }
            return apartments.AsEnumerable().ToArray();
        }
    }
}
