using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class SpeedMeasurementRepo : ISpeedMeasurementRepo
    {
        private List<SpeedMeasurement> _speedMeasurements;

        public SpeedMeasurementRepo()
        {
            _speedMeasurements = MockData.Measurements;
        }
        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            return _speedMeasurements;
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            _speedMeasurements.Add(new SpeedMeasurement(speed, imageName, location));
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
        }
    }
}
