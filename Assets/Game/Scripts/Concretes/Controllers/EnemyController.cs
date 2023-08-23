using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Movements;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class EnemyController : Controller
    {
        [SerializeField] float _speed;


        IMover _mover;

        private void Awake()
        {
            _mover = new ObjectMover(this);
        }

        private void FixedUpdate()
        {
            _mover.Move(_speed);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                Debug.Log("Accident! One right is over!");
            }

        }

    }
}

