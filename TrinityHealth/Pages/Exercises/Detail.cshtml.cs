using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrinityHealth.Core;
using TrinityHealth.Data;

namespace TrinityHealth
{
    public class DetailModel : PageModel
    {
        private readonly IExerciseData exerciseData;

        [TempData]
        public string Message { get; set; }

        public Exercise Exercise { get; set; }

        public DetailModel(IExerciseData exerciseData)
        {
            this.exerciseData = exerciseData;
        }

        public IActionResult OnGet(int exerciseId)
        {
            Exercise = exerciseData.GetById(exerciseId);
            if (Exercise == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}