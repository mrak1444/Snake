using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class InputController : IExecute
    {
        private string _route;
        private MoveSnake _moveSnake;

        public InputController(MoveSnake MoveSnake)
        {
            _moveSnake = MoveSnake;
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _moveSnake.Move("up");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _moveSnake.Move("down");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _moveSnake.Move("left");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _moveSnake.Move("right");
            }
        }
    }
}


