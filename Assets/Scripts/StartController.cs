using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _lose;
        [SerializeField] private Button _btnUp;
        [SerializeField] private Button _btnDown;
        [SerializeField] private Button _btnLeft;
        [SerializeField] private Button _btnRight;

        private ListExecuteObject _listExecuteObject;
        private Reference _reference;
        private HeadSnake _headSnake;
        private Apple _apple;
        private Score _score;
        private ScoreUI _scoreUI;
        private CoordinateController _coordinateController;
        private List<HeadSnake> Snakes = new List<HeadSnake>();
        //private HeadSnake[] Snakes;
        private MoveSnake _moveSnake;
        private InputController _inputController;
        private InputControllerUI _inputControllerUI;

        private void Awake()
        {
            _reference = new Reference();
            _headSnake = _reference.HeadSnake(new Vector3(0f, 0f, 0f));
            _moveSnake = new MoveSnake(_headSnake);
            _inputController = new InputController(_moveSnake);
            _inputControllerUI = new InputControllerUI(_moveSnake, _btnUp, _btnDown, _btnLeft, _btnRight);
            _score = new Score();
            _scoreUI = new ScoreUI(_score, _text);

            _apple = _reference.Apple();
            _coordinateController = new CoordinateController(_headSnake, Snakes, _apple);

            _moveSnake.HeadSnakePosition += HeadSnakePosition;
            _coordinateController.Overlap += Overlap;

            _listExecuteObject = new ListExecuteObject();

            _listExecuteObject.AddExecuteObject(_inputController);
            _listExecuteObject.AddExecuteObject(_moveSnake);
            _listExecuteObject.AddExecuteObject(_headSnake);
            _listExecuteObject.AddExecuteObject(_coordinateController);
            _listExecuteObject.AddExecuteObject(_scoreUI);


            Snakes.Add(_reference.HeadSnake(new Vector3(-0.5f, 0f, 0f)));
            Snakes.Add(_reference.HeadSnake(new Vector3(-1.0f, 0f, 0f)));

            for (int i = 0; i < Snakes.Count; i++)
            {
                _listExecuteObject.AddExecuteObject(Snakes[i]);
            }

            
        }

        void Update()
        {
            for (var i = 0; i < _listExecuteObject.Length; i++)
            {
                var interactiveObject = _listExecuteObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        private void HeadSnakePosition(Vector2 Position)
        {
            var pos = _headSnake.gameObject.transform.position;
            _headSnake.Run(Position);

            if(Snakes[0] != null)
            {
                Snakes[0].Run(pos);
                for (int i = 1; i < Snakes.Count; i++)
                {
                    Snakes[i].Run(Snakes[i - 1].transform.position);
                }
            }
        }

        private void Overlap(bool flag)
        {
            if (flag)
            {
                _apple.transform.position = _reference.Rnd();
                Snakes.Add(_reference.HeadSnake(Snakes[Snakes.Count - 1].transform.position));
                _listExecuteObject.AddExecuteObject(Snakes[Snakes.Count - 1]);
                _score.ScoreNum();
            }
            else
            {
                _lose.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}


