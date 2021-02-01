using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Services;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class EditLocationModel : PageModel
    {
        private Location _location;
        private LocationRepo _locationRepo;
        public EditLocationModel(ILocationRepo locationRepo)
        {
            _locationRepo = (LocationRepo)locationRepo;
        }
        [BindProperty]
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

       
       
        public void OnGet(int id)
        {
            _location = _locationRepo.GetLocation(id);
        }

        public IActionResult OnPostEdit()
        {
            _locationRepo.UpdateLocation(_location);
           return RedirectToPage("Index");

        }

        public IActionResult OnPostDelete()
        {
            _locationRepo.DeleteLocation(_location.Id);
            return RedirectToPage("Index");
        }
    }
}
