using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Movements
{
    public class PlayerMover : IMover
    {

        Controller _controller;

        private Vector2 touchStartPosition;

        private bool _oppositeDirection = false;
        private float _direction;
        private bool isDragging = false;
        private float targetPositionX = 0f;
        public float clampValue = 4.5f;

        public bool OppositeDirection { get { return _oppositeDirection; } set { _oppositeDirection = value; } }

        public PlayerMover(Controller controller)
        {
            _controller = controller;
            _direction = OppositeDirection ? -1 : 1;

        }

        public void Move(float speed)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPosition = touch.position;
                        isDragging = true;
                        break;

                    case TouchPhase.Moved:
                        Vector2 deltaPosition = touch.deltaPosition * _direction;
                        float deltaX = deltaPosition.x * Time.deltaTime * speed;
                        targetPositionX += deltaX;
                        break;

                    case TouchPhase.Ended:
                        isDragging = false;
                        break;
                }

            }
            targetPositionX = Mathf.Clamp(targetPositionX, -clampValue, clampValue);
            _controller.transform.position = new Vector3(Mathf.Lerp(_controller.transform.position.x, targetPositionX, Time.deltaTime * speed), _controller.transform.position.y, _controller.transform.position.z);
        }



    }
}

