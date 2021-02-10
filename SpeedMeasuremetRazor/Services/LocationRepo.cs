using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class LocationRepo : ILocationRepo
    {
        private List<Location> _locations;

        public LocationRepo()
        {
            _locations= MockData.Locations;
        }

        public List<Location> GetAllLocations()
        {
            return _locations;
        }

        public void AddLocation(Location location)
        {
            _locations.Add(location);
        }

        public void UpdateLocation(Location location)
        {
            Location toBeChanged = GetLocation(location.Id);
            toBeChanged.Address = location.Address;
            toBeChanged.SpeedLimit = location.SpeedLimit;
            toBeChanged.Zone = location.Zone;
        }

        public Location GetLocation(int id)
        {
            Location result = null;
            foreach (var location in _locations)
            {
                if (location.Id == id)
                {
                    result = location;
                }
            }

            return result;
        }

        public void DeleteLocation(int id)
        {
            _locations.Remove(GetLocation(id));
        }
    }
}
