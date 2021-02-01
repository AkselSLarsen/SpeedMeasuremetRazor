using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class MockData
    {
        private static List<Location> _locations;

        public static List<Location> Locations
        {
            get
            {
                if (_locations == null)
                {
                    _locations = new List<Location>();

                    _locations.Add(new Location("Maglegårdsvej 2", 50, Zone.By));
                    _locations.Add(new Location("Frederiksborgvej 120", 90, Zone.Motortrafikvej));
                    _locations.Add(new Location("Hillerødmotorvej 519", 130, Zone.By));
                }

                return _locations;
            }

        }

        private static List<SpeedMeasurement> _measurements;

        public static List<SpeedMeasurement> Measurements
        {
            get
            {
                List<SpeedMeasurement> measurements = new List<SpeedMeasurement>()
                {
                    //new SpeedMeasurement(45,Locations[0], RandomImage),
                    //new SpeedMeasurement(80, Locations[1], RandomImage),
                    //new SpeedMeasurement(130, Locations[2], RandomImage)
                };
                return measurements;
            }
        }

        private static List<string> _images = new List<string>()
        {
            "c1.jfif", "greycar.jfif", "nissan.jfif", "olsenbanden.jfif", "veteran.jfif", "whitecar.jfif",
            "whitetruck.jfif"
        };

        public static List<string> Images
        {
            get { return _images; }
        }

        private static Random r = new Random(DateTime.Now.Millisecond);
        public static string RandomImage
        {
            get
            {
                return _images[r.Next(0, _images.Count)];
            }
        }



    }
}
