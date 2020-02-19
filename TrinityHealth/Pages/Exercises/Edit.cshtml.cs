using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrinityHealth.Core;
using TrinityHealth.Data;

namespace TrinityHealth
{
    public class EditModel : PageModel
    {
        private readonly IExerciseData exerciseData;
        private readonly IHtmlHelper htmlHelper;
        
        [BindProperty]
        public Exercise Exercise { get; set; }

        public IEnumerable<SelectListItem> Muscles { get; set; }
        public EditModel(IExerciseData exerciseData, IHtmlHelper htmlHelper)
        {
            this.exerciseData = exerciseData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? exerciseId)
        {
            Muscles = htmlHelper.GetEnumSelectList<MuscleGroup>();
            if (exerciseId.HasValue)
            {
                Exercise = exerciseData.GetById(exerciseId.Value);
            }
            else
            {
                Exercise = new Exercise();
            }

            if (Exercise == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Muscles = htmlHelper.GetEnumSelectList<MuscleGroup>();
                return Page();
            }

            if (Exercise.Id > 0)
            {
                exerciseData.Update(Exercise);
            }
            else
            {
                exerciseData.Add(Exercise);
            }

            exerciseData.Commit();
            TempData["Message"] = "Exercise saved!";
            return RedirectToPage("./Detail", new { exerciseId = Exercise.Id });

        }
    }
}