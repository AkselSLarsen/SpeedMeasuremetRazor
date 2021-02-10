using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonSpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private string filepath = @"data\SpeedMeasurementData.json";
        private List<SpeedMeasurement> _speedMeasurements;

        public JsonSpeedMeasurementRepo()
        {
            _speedMeasurements = JsonHelper.ReadMeasurements(filepath);

            if(_speedMeasurements == null) {
            if(_speedMeasurements == null)
            {
                _speedMeasurements = new List<SpeedMeasurement>();
            }
        }

        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return _speedMeasurements;
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            SpeedMeasurement toBeAdded = new SpeedMeasurement(speed, imageName, location);
            int id = 1;
            while(!isUniqueId(id)) {
                id++;
            }
            toBeAdded.Id = id;
            _speedMeasurements.Add(toBeAdded);
            JsonHelper.WriteMeasurements(_speedMeasurements, filepath);
        }
        private bool isUniqueId(int id) {
            foreach(SpeedMeasurement sm in _speedMeasurements) {
                if(id == sm.Id) {
                    return false;
                }
            }
            return true;
        }

        public double AvarageSpeed()
        {
            double speedTotal = 0;
            foreach (SpeedMeasurement speedMeasurement in _speedMeasurements)
            {
                speedTotal += speedMeasurement.Speed;
            }

            return speedTotal / _speedMeasurements.Count;
        }

        public int NoOfOverSpeedLimit()
        {
            int overLimit = 0;
            foreach (SpeedMeasurement speedMeasurement in _speedMeasurements)
            {
                if (speedMeasurement.Location.SpeedLimit < speedMeasurement.Speed)
                {
                    overLimit++;
                }
            }

            return overLimit;
        }

        public int NoOfCutInLicense()
        {
            int cutinLicense = 0;
            for (int i = 0; i < _speedMeasurements.Count; i++)
            {
                if (_speedMeasurements[i].Location.SpeedLimit * 1.3 < _speedMeasurements[i].Speed)
                {
                    cutinLicense++;
                }
            }

            return cutinLicense;
        }

        public int NoOfCutInLicenseForeach()
        {
            int cutinLicense = 0;
            foreach (SpeedMeasurement speedMeasurement in _speedMeasurements)
            {
                if (speedMeasurement.Location.SpeedLimit * 1.3 < speedMeasurement.Speed)
                {
                    cutinLicense++;
                }
            }

            return cutinLicense;
        }

        public int NoOfConditionalRevocation()
        {
            int cutinLicense = 0;
            foreach (SpeedMeasurement speedMeasurement in _speedMeasurements)
            {
                if (speedMeasurement.Location.SpeedLimit * 1.3 < speedMeasurement.Speed && speedMeasurement.Location.SpeedLimit == 130)
                {
                    cutinLicense++;
                }
                else if (speedMeasurement.Location.SpeedLimit * 1.6 < speedMeasurement.Speed)
                {
                    cutinLicense++;
                }
            }

            return cutinLicense;
        }

        public int NoOfUnconditionalRevocation() {
            int cutinLicense = 0;
            foreach (SpeedMeasurement speedMeasurement in _speedMeasurements) {
                if (speedMeasurement.Location.SpeedLimit * 2 < speedMeasurement.Speed && speedMeasurement.Speed > 100) {
                    cutinLicense++;
                }
            }

            return cutinLicense;
        }

        public void DeleteSpeedMeasurement(int id)
        {
            SpeedMeasurement toBeDelted = null;
            foreach (SpeedMeasurement speedMeasurement in _speedMeasurements)
            {
                if (speedMeasurement.Id == id)
                {
                    toBeDelted = speedMeasurement;
                }
            }

            _speedMeasurements.Remove(toBeDelted);
            JsonHelper.WriteMeasurements(_speedMeasurements,filepath);
        }
        public List<SpeedMeasurement> CutInLicense()
        {
            List<SpeedMeasurement> l = new List<SpeedMeasurement>();
            for (int i = 0; i < _speedMeasurements.Count; i++)
            {
                if (_speedMeasurements[i].Location.SpeedLimit * 1.3 < _speedMeasurements[i].Speed)
                {
                    l.Add(_speedMeasurements[i]);
                }
            }

            return l;
        }
    }
}
