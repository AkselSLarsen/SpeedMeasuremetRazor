using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Services;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private LocationRepo _locationRepo;

        public LocationRepo LocationRepo {
            get { return _locationRepo; }
            set { _locationRepo = value; }
        }

        public IndexModel(ILocationRepo locationRepo) {
            _locationRepo = (LocationRepo)locationRepo;
        }

        public void OnGet()
        {
        }


    }
}
