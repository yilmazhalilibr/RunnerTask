using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Abstracts.Patterns;
using RunnerTask.Movements;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class ObjectController : Controller
    {
        [SerializeField] float _speed;
        [SerializeField] bool _onlyOneTime;
        [SerializeField] bool _oppositeDirection = false;

        IMover _mover;

        public bool OppositeDirection { get { return _oppositeDirection; } set { _oppositeDirection = value; } }

        private void Awake()
        {
            _mover = new ObjectMover(this);
            _speed = _oppositeDirection ? -1f * (_speed) : _speed;

        }

        private void FixedUpdate()
        {
            _mover.Move(_speed);
            OneTimeWork();
        }

        private void OneTimeWork()
        {
            if (_onlyOneTime && transform.position.z <= -10f)
            {
                gameObject.SetActive(false);
            }

        }




    }
}

