using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class LocationSortByZone : IComparer<Location>
    {
        public int Compare(Location x, Location y)
        {
            return x.Zone.CompareTo(y.Zone);
        }
    }
}
