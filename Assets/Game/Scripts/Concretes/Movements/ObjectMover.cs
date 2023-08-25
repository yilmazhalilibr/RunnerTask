using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using UnityEngine;

namespace RunnerTask.Movements
{
    public class ObjectMover : IMover
    {
        Controller _controller;

        private bool _oppositeDirection = false;
        private float _direction;
        public bool OppositeDirection { get { return _oppositeDirection; } set { _oppositeDirection = value; } }

        public ObjectMover(Controller controller)
        {
            _controller = controller;
            _direction = OppositeDirection ? -1 : 1;
        }

        public void Move(float speed)
        {
            _controller.transform.Translate(new Vector3(0f, 0f, -1f * _direction) * Time.deltaTime * speed);
        }



    }
}

