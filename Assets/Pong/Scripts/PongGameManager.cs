using TMPro;
using UnityEngine;

namespace Pong.Scripts
{
    public class PongGameManager : MonoBehaviour
    {
        public Ball ball;
        private int _playerScore;
        private int _aiScore;
        public TextMeshPro playerScoreText;
        public TextMeshPro aiScoreText;
        

        public void PlayerScore()
        {
            _playerScore++;
            playerScoreText.text = _playerScore.ToString();
            ball.ResetPosition();
        }

        public void AiScore()
        {
            _aiScore++;
            aiScoreText.text = _aiScore.ToString();
            ball.ResetPosition();
        }
        
    }
}
