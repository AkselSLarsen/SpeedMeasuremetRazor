using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonHelper
    {
        public static List<Location> ReadLocations(string filepath)
        {
            string jsonString = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<Location>>(jsonString);
        }

        public static void WriteLocation(List<Location> locations, string filepath)
        {
            string output = JsonConvert.SerializeObject(locations,Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filepath, output);
        }

        public static List<SpeedMeasurement> ReadMeasurements(string filepath)
        {
            string jsonString = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<SpeedMeasurement>>(jsonString);
        }
        public static void WriteMeasurements(List<SpeedMeasurement> measurements, string filepath)
        {
            string output = JsonConvert.SerializeObject(measurements, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filepath, output);
        }
    }
}
