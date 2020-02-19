using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrinityHealth.Data;

namespace TrinityHealth.ViewComponents
{
    public class ExerciseCountViewComponent : ViewComponent
    {
        private readonly IExerciseData exerciseData;
        public ExerciseCountViewComponent(IExerciseData exerciseData)
        {
            this.exerciseData = exerciseData;
            
        }

       public IViewComponentResult Invoke()
        {
            var count = exerciseData.GetCountofExercises();
            return View(count);
        }
    }
}
