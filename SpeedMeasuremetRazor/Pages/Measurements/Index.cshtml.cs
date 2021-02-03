using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        public ISpeedMeasurementRepo repo;


        public IndexModel(ISpeedMeasurementRepo repository)
        {
            repo = repository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {
            repo.DeleteSpeedMeasurement(id);
            return Page();
        }
    }
}
