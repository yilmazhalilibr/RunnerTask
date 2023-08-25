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

        public int Rights { get { return _rights; } set { if (value >= 0) _rights = value; } }

        public event System.Action OnRightRemoved;
        private void Awake()
        {
            _mover = new PlayerMover(this);
        }
        private void Start()
        {
            _speed = _player.Speed;
            _rights = _player.Rights;
        }

        private void FixedUpdate()
        {
            _mover.Move(_speed);
        }

        public void RemoveRight()
        {
            _rights--;
            OnRightRemoved?.Invoke();
        }



    }

}
