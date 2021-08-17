using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class MoveSnake : IExecute
    {
        private HeadSnake _headSnake;
        private string _route;
        private Vector2 _positionFirst;
        private Vector2 _positionNext;
        public event Action<Vector2> HeadSnakePosition = delegate (Vector2 i) { };

        public MoveSnake(HeadSnake headSnake)
        {
            _headSnake = headSnake;
            //_positionFirst = _headSnake.transform.position;
        }

        public void Move(string route)
        {
            _route = route;
            //_positionFirst = _headSnake.transform.position;
            if (_positionFirst == _positionNext)
            {
                switch (_route)
                {
                    case "up":
                        _positionNext = new Vector2(_positionFirst.x, _positionFirst.y + 0.5f);
                        break;
                    case "down":
                        _positionNext = new Vector2(_positionFirst.x, _positionFirst.y - 0.5f);
                        break;
                    case "left":
                        _positionNext = new Vector2(_positionFirst.x - 0.5f, _positionFirst.y);
                        break;
                    case "right":
                        _positionNext = new Vector2(_positionFirst.x + 0.5f, _positionFirst.y);
                        break;
                    default:
                        _positionNext = new Vector2(_positionFirst.x + 0.5f, _positionFirst.y);
                        break;
                }
            }
            HeadSnakePosition.Invoke(_positionNext);
        }

        public void Execute()
        {
            _positionFirst = _headSnake.transform.position;
            if (_positionFirst == _positionNext)
            {
                
                Move(_route);
            }
        }
    }
}

