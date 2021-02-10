using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class CreateLocationModel : PageModel
    {
        private ILocationRepo repo;
        [BindProperty]
        public Location Location { get; set; }

        public CreateLocationModel(ILocationRepo repository)
        {
            
            repo = repository;

        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            repo.AddLocation(Location.Address, Location.SpeedLimit, Location.Zone);
            return RedirectToPage("Index");
        }
    }
}
