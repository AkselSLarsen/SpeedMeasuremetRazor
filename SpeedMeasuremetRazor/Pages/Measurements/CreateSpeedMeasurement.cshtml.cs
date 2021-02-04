using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Services;
using SpeedMeasuremetRazor.Exceptions;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class CreateSpeedMeasurementModel : PageModel
    {
        private SpeedMeasurementRepo _measurementRepo;
        private LocationRepo _locationRepo;
        public string message;

        public SpeedMeasurementRepo MeasurementRepo {
            get { return _measurementRepo; }
            set { _measurementRepo = value; }
        }

        public LocationRepo LocationRepo {
            get { return _locationRepo; }
            set { _locationRepo = value; }
        }


        public CreateSpeedMeasurementModel(ILocationRepo locRepo, ISpeedMeasurementRepo speedRepo) {
            _locationRepo = (LocationRepo)locRepo;
            _measurementRepo = (SpeedMeasurementRepo)speedRepo;
            message = "Look in the viewfinder and press the button";
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(int locId) {
            Location loc = LocationRepo.GetLocation(locId);
            Random random = new Random();
            try
            {
                MeasurementRepo.AddSpeedMeasurement(random.Next(-20, 376), loc, MockData.RandomImage);
            }
            catch(CalibrationException e)
            {
                message = e.Message;
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
