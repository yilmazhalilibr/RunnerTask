using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using UnityEngine;

namespace RunnerTask.Movements
{
    public class Mover : IMover
    {
        Controller _controller;
        public Mover(Controller controller)
        {
            _controller = controller;
        }

        public void Move(float speed)
        {
            _controller.transform.Translate(new Vector3(0f, 0f, -1f) * Time.deltaTime * speed);
        }



    }
}

