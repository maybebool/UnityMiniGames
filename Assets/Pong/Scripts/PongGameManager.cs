using TMPro;
using UnityEngine;

namespace Pong.Scripts {
    
    public class PongGameManager : MonoBehaviour {
        
        public Ball ball;
        private int _playerScore;
        private int _aiScore;
        public Paddle playerPaddle;
        public Paddle aiPaddle;
        
        public TextMeshPro playerScoreText;
        public TextMeshPro aiScoreText;
        

        public void PlayerScore() {
            _playerScore++;
            playerScoreText.text = _playerScore.ToString();
            playerPaddle.ResetPosition();
            aiPaddle.ResetPosition();
            ball.ResetPosition();
            ball.AddStartForce();
        }

        public void AiScore() {
            _aiScore++;
            aiScoreText.text = _aiScore.ToString();
            playerPaddle.ResetPosition();
            aiPaddle.ResetPosition();
            ball.ResetPosition();
            ball.AddStartForce();
        }
    }
}
