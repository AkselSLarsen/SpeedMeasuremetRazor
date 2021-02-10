using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonLocationRepo : ILocationRepo
    {
        private string filepath = @"Data\LocationData.json";
        private List<Location> _locations;
        public JsonLocationRepo()
        {
            _locations = JsonHelper.ReadLocations(filepath);

            if(_locations == null) {
                _locations = new List<Location>();
            }
        }

        public List<Location> GetAllLocations()
        {
            return _locations;
        }

        public void AddLocation(string address, int speedLimit, Zone zone)
        {
            Location location = new Location(address, speedLimit, zone);
            int id = 1;
            while(!isUnique(id)) {
                id++;
            }
            location.Id = id;

            _locations.Add(location);
            JsonHelper.WriteLocation(_locations,filepath);
        }
        private bool isUnique(int id) {
            foreach(Location l in _locations) {
                if(id == l.Id) {
                    return false;
                }
            }
            return true;
        }

        public void UpdateLocation(Location location)
        {
            Location toBeChanged = GetLocation(location.Id);
            toBeChanged.Address = location.Address;
            toBeChanged.SpeedLimit = location.SpeedLimit;
            toBeChanged.Zone = location.Zone;
            JsonHelper.WriteLocation(_locations,filepath);
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
            JsonHelper.WriteLocation(_locations,filepath);
        }
    }
}
