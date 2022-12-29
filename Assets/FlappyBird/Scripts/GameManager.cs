using UnityEngine;

namespace FlappyBird.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private int _score;

        public void GameOver()
        {
            Debug.Log("game over");
        }

        public void IncreaseScore()
        {
            _score++;
            Debug.Log($"Score" + _score);
        }
    }
}
