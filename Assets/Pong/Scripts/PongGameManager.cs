using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Pong.Scripts {
    public class PongGameManager : MonoBehaviour {
        
        [SerializeField] private Ball ball;
        [SerializeField] private Paddle playerPaddle;
        [SerializeField] private Paddle aiPaddle;

        [SerializeField] private TMP_Text playerScoreText;
        [SerializeField] private TMP_Text aiScoreText;

        [SerializeField] private GameObject uiPanel;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button quitButton;

        private void OnEnable() {
            continueButton.onClick.AddListener(OnClickContinueButton);
            quitButton.onClick.AddListener(OnClickQuitButton);
        }

        private void OnDisable() {
            continueButton.onClick.RemoveListener(OnClickContinueButton);
            quitButton.onClick.RemoveListener(OnClickQuitButton);
        }

        private void Update() {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            OpenPauseMenu();
        }


        private void OpenPauseMenu() {
            uiPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void OnClickContinueButton() {
            uiPanel.SetActive(false);
            Time.timeScale = 1f;
        }

        private void OnClickQuitButton() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
        

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