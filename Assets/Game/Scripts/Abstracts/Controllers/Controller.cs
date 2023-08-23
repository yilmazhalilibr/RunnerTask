using RunnerTask.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Abstracts.Controllers
{
    public abstract class Controller : MonoBehaviour
    {
        public virtual List<GameObject> ActiveEnemies { get; protected set; }
        public virtual bool SingleType { get; protected set; }
    }
}

