using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeedMeasuremetRazor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Exceptions;

namespace SpeedMeasuremetRazor.Services.Speedrepo
{
    [TestClass()]
    public class SpeedMeasurementRepoTests
    {
        private static SpeedMeasurementRepo speedrepo = new SpeedMeasurementRepo();
        private static Location Loc = new Location("test",100,Zone.By);
        [TestMethod()]
        [ExpectedException(typeof(CalibrationException))]
        public void AddSpeedMeasurementTest301()
        {
            speedrepo.AddSpeedMeasurement(301,Loc,"");
        }
        [TestMethod()]
        public void AddSpeedMeasurementTest300()
        {
            int before = speedrepo.GetAllSpeedMeasurements().Count;
            speedrepo.AddSpeedMeasurement(300,Loc,"");
            int after = speedrepo.GetAllSpeedMeasurements().Count;
            Assert.AreEqual(before+1,after);
        }
        [TestMethod()]
        [ExpectedException(typeof(CalibrationException))]

        public void AddSpeedMeasurementTestnegative1()
        {
            speedrepo.AddSpeedMeasurement(-1,Loc,"");
        }
        [TestMethod()]
        public void AddSpeedMeasurementTest0()
        {
            int before = speedrepo.GetAllSpeedMeasurements().Count;
            speedrepo.AddSpeedMeasurement(0, Loc, "");
            int after = speedrepo.GetAllSpeedMeasurements().Count;
            Assert.AreEqual(before + 1, after);
        }
    }
}