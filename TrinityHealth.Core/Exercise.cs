using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrinityHealth.Core
{

    public class Exercise 
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(160)]
        public string Description { get; set; }

        public MuscleGroup Muscle { get; set; }
    }
}
