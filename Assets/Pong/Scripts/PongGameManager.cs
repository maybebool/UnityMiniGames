using TMPro;
using UnityEngine;

namespace Pong.Scripts {
    public class PongGameManager : MonoBehaviour {
        
        public Ball ball;
        public Paddle playerPaddle;
        public Paddle aiPaddle;

        public TMP_Text playerScoreText;
        public TMP_Text aiScoreText;

        private int _playerScore;
        private int _aiScore;

        public void PlayerScore() {
            _playerScore++;
            playerScoreText.text = _playerScore.ToString();
            ResetRound();
        }

        public void AiScore() {
            _aiScore++;
            aiScoreText.text = _aiScore.ToString();
            ResetRound();
        }

        private void ResetRound() {
            playerPaddle.ResetPosition();
            aiPaddle.ResetPosition();
            ball.ResetPosition();
            ball.AddStartForce();
        }
    }
}