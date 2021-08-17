namespace Snake
{
    public class Score
    {
        private int _score = 0;

        public int score
        {
            get
            {
                return _score;
            }
        }

        public void ScoreNum()
        {
            _score++;
        }
    }
}