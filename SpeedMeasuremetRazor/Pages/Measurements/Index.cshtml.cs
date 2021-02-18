using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Services;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Helpers;

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

        public IActionResult OnPostFilter(int filter, string textfilter)
        {
            if (filter == 1)
            {
                filterList = fullRepo.GetAllSpeedMeasurements();
            }
            if(filter == 2)
            {
                filterList = fullRepo.CutInLicense();
            }

            if (filter == 3)
            {
                filterList = fullRepo.ConditionalRevocation();
            }

            if (filter == 4)
            {
                filterList = fullRepo.UnconditionalRevocation();
            }

            if (textfilter != null)
            {
                Predicate<SpeedMeasurement> predicate = measurement =>
                {
                   return measurement.Location.Address.ToLower().Contains(textfilter.ToLower());
                };
                filterList = GenericFilter.Filter(filterList, predicate);
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