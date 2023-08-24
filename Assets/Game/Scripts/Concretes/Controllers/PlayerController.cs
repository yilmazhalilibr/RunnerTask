using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Movements;
using RunnerTask.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class PlayerController : Controller
    {
        [SerializeField] PlayerSO _player;

        private float _speed;
        private int _rights;

        IMover _mover;

        public int Rights { get { return _rights; } set { _rights = value; } }

        private void Awake()
        {
            _mover = new PlayerMover(this);

            _speed = _player.Speed;
            _rights = _player.Rights;

        }

        private void FixedUpdate()
        {
            _mover.Move(_speed);
        }

    }

}
