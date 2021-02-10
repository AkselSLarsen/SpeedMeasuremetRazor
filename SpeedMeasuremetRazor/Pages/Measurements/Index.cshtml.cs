using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Services;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        public List<SpeedMeasurement> filterList;
        public JsonSpeedMeasurementRepo fullRepo;
        public IndexModel(ISpeedMeasurementRepo repository)
        {
            fullRepo = (JsonSpeedMeasurementRepo)repository;
            filterList = fullRepo.GetAllSpeedMeasurements();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostFilter(int filter)
        {
            if(filter == 1)
            {
                filterList = fullRepo.CutInLicense();
            }

            if (filter == 2)
            {
                filterList = fullRepo.ConditionalRevocation();
            }

            if (filter == 3)
            {
                filterList = fullRepo.UnconditionalRevocation();
            }
            return Page();
        }
        public IActionResult OnPost(int deletemeasurement)
        {
            fullRepo.DeleteSpeedMeasurement(deletemeasurement);
            return Page();
        }
    }
}