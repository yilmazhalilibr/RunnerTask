using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Movements;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class ObjectController : Controller
    {
        [SerializeField] float _speed;


        IMover _mover;

        private void Awake()
        {
            _mover = new Mover(this);
        }

        private void FixedUpdate()
        {
            _mover.Move(_speed);
        }
    }
}

