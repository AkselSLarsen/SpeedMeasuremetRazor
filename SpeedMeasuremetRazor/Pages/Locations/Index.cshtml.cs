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

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private ILocationRepo _locationRepo;
        public List<Location> _locationSortedList;
        public ILocationRepo LocationRepo {
            get { return _locationRepo; }
            set { _locationRepo = value; }
        }

        public IndexModel(ILocationRepo locationRepo) {
            _locationRepo = (ILocationRepo)locationRepo;
            _locationSortedList = _locationRepo.GetAllLocations();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSort(int sort)
        {
            if (sort == 1)
            {
                _locationSortedList.Sort();
            }
            if (sort == 2)
            {
                _locationSortedList.Sort(new LocationSortBySpeed());
            }

            if (sort == 3)
            {
                _locationSortedList.Sort(new LocationSortByZone());
            }

            return Page();
        }

    }
}
