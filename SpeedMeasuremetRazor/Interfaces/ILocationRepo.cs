using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Interfaces
{
    public interface ILocationRepo
    {
        List<Location> GetAllLocations();
        void AddLocation(string address, int speedLimit, Zone zone);
        void UpdateLocation(Location location);

        Location GetLocation(int id);
        void DeleteLocation(int id);
    }
}
