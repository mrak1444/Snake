using System;
using System.Collections.Generic;

namespace Snake
{
    public class CoordinateController : IExecute
    {
        private HeadSnake _headSnake;
        private List<HeadSnake> _snakes;
        private Apple _apple;
        public event Action<bool> Overlap = delegate (bool i) { };

        public CoordinateController(HeadSnake HeadSnake, List<HeadSnake> Snakes, Apple Apple)
        {
            _headSnake = HeadSnake;
            _snakes = Snakes;
            _apple = Apple;
        }

        public void Execute()
        {
            if (_headSnake.transform.position == _apple.transform.position) Overlap.Invoke(true);
            if (_headSnake.transform.position.x <= -2.2f || _headSnake.transform.position.x >= 2.2f) Overlap.Invoke(false);
            if (_headSnake.transform.position.y >= 4.3f || _headSnake.transform.position.y <= -5) Overlap.Invoke(false);
            for(int i = 0; i < _snakes.Count; i++)
            {
                if (_headSnake.transform.position == _snakes[i].transform.position) Overlap.Invoke(false);
            }
        }
    }
}