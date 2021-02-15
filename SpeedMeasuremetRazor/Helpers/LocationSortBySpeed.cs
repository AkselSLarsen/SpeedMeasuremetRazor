using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class LocationSortBySpeed : IComparer<Location>
    {
        public int Compare(Location x, Location y)
        {
            return x.SpeedLimit < y.SpeedLimit ? -1 : (x.SpeedLimit == y.SpeedLimit ? 0 : 1);
        }
    }
}
