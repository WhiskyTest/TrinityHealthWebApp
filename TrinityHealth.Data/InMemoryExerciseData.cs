using System;
using System.Collections.Generic;
using TrinityHealth.Core;
using System.Linq;

namespace TrinityHealth.Data
{
    public class InMemoryExerciseData : IExerciseData
    {
        readonly List<Exercise> exercises;
        public InMemoryExerciseData()
        {
            exercises = new List<Exercise>()
            { 
                new Exercise { Id = 1, Name = "Arm Press", Description = "Press those arms", Muscle = MuscleGroup.Arms }
            };
        }

        public Exercise Add(Exercise newExercise)
        {
            exercises.Add(newExercise);
            newExercise.Id = exercises.Max(r => r.Id) + 1;
            return newExercise;
        }

        public int Commit()
        {
            return 0;
        }

        public Exercise Delete(int id)
        {
            var exercise = exercises.FirstOrDefault(r => r.Id == id);
            if (exercise != null)
            {
                exercises.Remove(exercise);
            }
            return exercise;
        }

        public Exercise GetById(int id)
        {
            return exercises.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountofExercises()
        {
            return exercises.Count();
        }

        public IEnumerable<Exercise> GetExercisesByName(string name = null)
        {
        return from r in exercises
               where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
               orderby r.Name
               select r;
        }

        public Exercise Update(Exercise updatedExercise)
        {
            var exercise = exercises.SingleOrDefault(r => r.Id == updatedExercise.Id);

            if(exercise != null)
            {
                exercise.Name = updatedExercise.Name;
                exercise.Description = updatedExercise.Description;
                exercise.Muscle = updatedExercise.Muscle;
            }
            return exercise;
        }
    }
}
