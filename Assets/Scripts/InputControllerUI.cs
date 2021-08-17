using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class InputControllerUI
    {
        private MoveSnake _moveSnake;
        private Button _btnUp;
        private Button _btnDown;
        private Button _btnLeft;
        private Button _btnRight;

        public InputControllerUI(MoveSnake MoveSnake, Button btnUp, Button btnDown, Button btnLeft, Button btnRight)
        {
            _moveSnake = MoveSnake;
            _btnUp = btnUp;
            _btnUp.onClick.AddListener(BtnUp);
            _btnDown = btnDown;
            _btnDown.onClick.AddListener(BtnDown);
            _btnLeft = btnLeft;
            _btnLeft.onClick.AddListener(BtnLeft);
            _btnRight = btnRight;
            _btnRight.onClick.AddListener(BtnRight);
        }

        private void BtnUp()
        {
            _moveSnake.Move("up");
        }

        private void BtnDown()
        {
            _moveSnake.Move("down");
        }

        private void BtnLeft()
        {
            _moveSnake.Move("left");
        }

        private void BtnRight()
        {
            _moveSnake.Move("right");
        }
    }
}