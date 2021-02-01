using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class SpeedMeasurement
    {
        private int _id;
        private static int _staticId;
        private DateTime _timeStamp;
        private int _speed;
        private string _picture;

        SpeedMeasurement(int speed, string picture) {
            _id = _staticId++;
            // "var1 = ++var2;" is shorthand for "var2 + 1; var1 = var2;" whereas,
            // "var1 = var2++;" is shorthand for "var1 = var2; var2 + 1;".
            _timeStamp = DateTime.Now;
            _speed = speed;
            _picture = picture;
        }

        public int Id {
            get { return _id; }
            set { _id = value; }
        }
        public string Picture {
            get { return _picture; }
            set { _picture = value; }
        }
        public int Speed {
            get { return _speed; }
            set { _speed = value; }
        }
        public DateTime TimeStamp {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
    }
}
