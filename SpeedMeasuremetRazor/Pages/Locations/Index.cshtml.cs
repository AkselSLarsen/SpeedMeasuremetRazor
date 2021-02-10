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
        private ILocationRepo _locationRepo;

        public ILocationRepo LocationRepo {
            get { return _locationRepo; }
            set { _locationRepo = value; }
        }

        public IndexModel(ILocationRepo locationRepo) {
            _locationRepo = (ILocationRepo)locationRepo;
        }

        public void OnGet()
        {
        }


    }
}
