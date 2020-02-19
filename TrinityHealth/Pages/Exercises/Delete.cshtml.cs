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
    public class DeleteModel : PageModel
    {
        private readonly IExerciseData exerciseData;
        public Exercise Exercise { get; set; }

        public DeleteModel(IExerciseData exerciseData)
        {
            this.exerciseData = exerciseData;
        }
        public IActionResult OnGet(int exerciseId)
        {
            Exercise = exerciseData.GetById(exerciseId);
            if(Exercise == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int exerciseId)
        {
         var exercise =   exerciseData.Delete(exerciseId);
            exerciseData.Commit();

            if (exercise == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{exercise.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}