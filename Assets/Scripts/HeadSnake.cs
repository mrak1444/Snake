using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class HeadSnake : MonoBehaviour, IExecute
    {
        private Vector2 _positionFirst;
        private Vector2 _positionNext;
        

        public void Run(Vector2 PositionNext)
        {
            _positionNext = PositionNext;
        }

        public void Execute()
        {
            transform.position = Vector2.MoveTowards(transform.position, _positionNext, Time.deltaTime);
        }
    }
}
