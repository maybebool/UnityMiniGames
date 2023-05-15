using UnityEngine;

namespace Pong.Scripts
{
    public class PongGameManager : MonoBehaviour
    {
        public Ball ball;
        private int _playerScore;
        private int _aiScore;

        public void PlayerScore()
        {
            _playerScore++;
            ball.ResetPosition();
        }

        public void AiScore()
        {
            _aiScore++;
            ball.ResetPosition();
        }
        
    }
}
