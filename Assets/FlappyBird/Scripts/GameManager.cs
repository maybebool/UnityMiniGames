using UnityEngine;

namespace FlappyBird.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private int _score;

        private void GameOver()
        {
            Debug.Log("game over");
        }

        private void IncreaseScore()
        {
            _score++;
        }
    }
}
