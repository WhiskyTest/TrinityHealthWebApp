using System.Collections.Generic;
using System.Text;
using TrinityHealth.Core;

namespace TrinityHealth.Data
{
    public interface IExerciseData
    {
        IEnumerable<Exercise> GetExercisesByName(string name);
        Exercise GetById(int id);
        Exercise Update(Exercise updatedExercise);
        int Commit();
        Exercise Add(Exercise newExercise);
        Exercise Delete(int id);

        int GetCountofExercises();
    }
}
