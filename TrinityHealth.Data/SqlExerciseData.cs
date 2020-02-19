using System.Collections.Generic;
using TrinityHealth.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TrinityHealth.Data
{
    public class SqlExerciseData : IExerciseData
    {
        private readonly TrinityHealthDbContext db;
        public SqlExerciseData(TrinityHealthDbContext db)
        {
            this.db = db;
        }
        public Exercise Add(Exercise newExercise)
        {
            db.Add(newExercise);
            return newExercise;
        }

        public int Commit()
        {
           return db.SaveChanges();
        }

        public Exercise Delete(int id)
        {
            var exercise = GetById(id);
            if (exercise != null)
            {
                db.Exercises.Remove(exercise);
            }
            return exercise;
        }

        public Exercise GetById(int id)
        {
            return db.Exercises.Find(id);
        }

        public int GetCountofExercises()
        {
            return db.Exercises.Count();
        }

        public IEnumerable<Exercise> GetExercisesByName(string name)
        {
            var query = from r in db.Exercises
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Exercise Update(Exercise updatedExercise)
        {
            var entity = db.Exercises.Attach(updatedExercise);
            entity.State = EntityState.Modified;
            return updatedExercise;
        }
    }
}
