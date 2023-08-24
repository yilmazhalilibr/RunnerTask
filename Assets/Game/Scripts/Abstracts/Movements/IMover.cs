using UnityEngine;

namespace RunnerTask.Abstracts.Movements
{
    public interface IMover
    {
        bool OppositeDirection { get; set; }

        void Move(float speed);
    }
}

