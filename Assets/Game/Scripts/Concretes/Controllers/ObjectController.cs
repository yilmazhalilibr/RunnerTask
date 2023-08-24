using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Movements;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class ObjectController : Controller
    {
        [SerializeField] float _speed;
        [SerializeField] bool _onlyOneTime;

        IMover _mover;

        private void Awake()
        {
            _mover = new ObjectMover(this);
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

