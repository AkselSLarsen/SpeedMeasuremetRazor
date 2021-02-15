using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Exceptions
{
    public class CalibrationException : Exception
    {
        public CalibrationException() {
        }

        public CalibrationException(string message) : base(message)
        {

        }

    }
}
