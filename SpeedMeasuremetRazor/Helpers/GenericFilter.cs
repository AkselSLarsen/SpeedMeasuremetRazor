using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Helpers
{
    public class GenericFilter
    {
        public static List<T> Filter<T>(List<T> list, Predicate<T> pred)
        {
            return list.FindAll(pred);
        }
    }
}
