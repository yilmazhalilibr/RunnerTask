using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class PlayerController : Controller
    {
        [SerializeField] float _speed;

        IMover _mover;

        private void Awake()
        {
            _mover = new PlayerMover(this);
        }

        private void FixedUpdate()
        {
            _mover.Move(_speed);
        }

    }

}
