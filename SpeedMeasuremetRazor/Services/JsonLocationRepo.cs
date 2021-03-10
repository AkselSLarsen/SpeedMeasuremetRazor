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
        private static string filepath = @"Data\LocationData.json";
        private List<Location> _locations;
        private Task<List<Location>> _taskLocation = JsonHelper.ReadAsync<Location>(filepath);
        public JsonLocationRepo()
        {
            _ = Load();
        }
        private async Task Load() {
            _locations = await _taskLocation;
        }

        public List<Location> GetAllLocations()
        {
            if(_taskLocation.IsCompleted) {
                if (_locations == null) {
                    _locations = new List<Location>();
                }
                return _locations;
            } else {
                System.Threading.Thread.Sleep(10);
                return GetAllLocations();
            }
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
            JsonHelper.WriteAsync<Location>(_locations,filepath);
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
            JsonHelper.WriteAsync<Location>(_locations,filepath);
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
            JsonHelper.WriteAsync<Location>(_locations,filepath);
        }
    }
}
