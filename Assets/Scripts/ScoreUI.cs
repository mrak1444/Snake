using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class ScoreUI : IExecute
    {
        private Text _text;
        private Score _score;

        public ScoreUI(Score Score, Text Text)
        {
            _score = Score;
            _text = Text;
        }

        public void Execute()
        {
            _text.text = _score.score.ToString();
        }
    }
}
