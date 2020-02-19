using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TrinityHealth.Core;
using TrinityHealth.Data;

namespace TrinityHealth
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        private readonly IConfiguration config;
        private readonly IExerciseData exerciseData;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }

        public ListModel(IConfiguration config, IExerciseData exerciseData)
        {
            this.config = config;
            this.exerciseData = exerciseData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Exercises = exerciseData.GetExercisesByName(SearchTerm);
        }
    }
}