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

            if (transform.position.z <= -10f)
            {
                transform.position.Set(0, 0, 0);
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                //Debug.Log("Accident! One right is gone!");
                playerController.RemoveRight();
            }

        }

    }
}

