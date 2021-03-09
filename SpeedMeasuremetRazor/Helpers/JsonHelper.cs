using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Pages.Locations;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonHelper
    {
        private static List<Exception> _readExceptions = new List<Exception>();

        public static List<Exception> GetReadExceptions {
            get { return _readExceptions; }
        }

        public static List<T> ReadAsync<T>(string filepath) {
            string jsonString = "";
            try {
                Task<string> task = readAsync(filepath);
                jsonString = task.Result;
            } catch (Exception e) {
                _readExceptions.Add(e);
            }

            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }
        private static async Task<string> readAsync(string filepath) {
            string jsonString = "";
            try {
                jsonString = await File.ReadAllTextAsync(filepath);
            } catch (Exception e) {
                _readExceptions.Add(e);
            }
            return jsonString;
        }

        public static async void WriteAsync<T>(List<T> t, string filepath) {
            string output = JsonConvert.SerializeObject(t, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(filepath, output);
        }

        [Obsolete] //Use ReadAsync<T>(string) instead
        public static List<T> Read<T>(string filepath) {

            string jsonString = "";
            try {
                jsonString = File.ReadAllText(filepath);
            } catch (Exception e) {
                _readExceptions.Add(e);
            }

            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        [Obsolete]
        //Use WriteAsync<T>(List<T>, string) instead
        public static void Write<T>(List<T> t, string filepath) {
            string output = JsonConvert.SerializeObject(t, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filepath, output);
        }

        [Obsolete]
        public static List<Location> ReadLocations(string filepath)
        {
            string jsonString = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<Location>>(jsonString);
        }

        [Obsolete]
        public static void WriteLocation(List<Location> locations, string filepath)
        {
            string output = JsonConvert.SerializeObject(locations,Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filepath, output);
        }

        [Obsolete]
        public static List<SpeedMeasurement> ReadMeasurements(string filepath)
        {
            string jsonString = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<SpeedMeasurement>>(jsonString);
        }

        [Obsolete]
        public static void WriteMeasurements(List<SpeedMeasurement> measurements, string filepath)
        {
            string output = JsonConvert.SerializeObject(measurements, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filepath, output);
        }
    }
}