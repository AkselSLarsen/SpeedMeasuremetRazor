using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class Location
    {
        private int _id;
        private string _address;
        private int _speedLimit;

        //test
        public Location(string address, int speedLimit, Zone zone)
        {
            _address = address;
            _speedLimit = speedLimit;
            Zone = zone;
        }

        public Location()
        {
        }
        

        public Zone Zone { get; set; }
        public int SpeedLimit
        {
            get { return _speedLimit; }
            set { _speedLimit = value; }
        }


        public string  Address
        {
            get { return _address; }
            set { _address = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
