using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class Reference
    {
        private HeadSnake _headSnake;
        private Apple _apple;
        private int _goodBonusPositionX;
        private int _goodBonusPositionY;

        public Vector3 Rnd()
        {
            _goodBonusPositionX = Random.Range(-8, 8);
            _goodBonusPositionY = Random.Range(-4, 4);
            Vector3 RndPositionBonus = new Vector3(_goodBonusPositionX, _goodBonusPositionY, 0f);
            return RndPositionBonus;
        }

        public HeadSnake HeadSnake(Vector3 vector)
        {
            var gameObject = Resources.Load<HeadSnake>("Prefabs/HeadSnake");
            _headSnake = Object.Instantiate(gameObject, vector, Quaternion.identity);
            return _headSnake;
        }

        public Apple Apple()
        {
            var gameObject = Resources.Load<Apple>("Prefabs/Apple");
            _apple = Object.Instantiate(gameObject, Rnd(), Quaternion.identity);
            return _apple;
        }
    }
}

