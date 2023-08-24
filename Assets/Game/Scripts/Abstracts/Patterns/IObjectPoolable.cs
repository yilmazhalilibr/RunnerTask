using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Abstracts.Patterns
{
    public interface IObjectPoolable
    {
        bool SingleType { get; }
        IEnumerator SpawnRoutine();
        IEnumerator SpawnRoutineRandomTime();
    }
}

