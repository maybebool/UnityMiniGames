using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleShooter.Scripts {
    public class BubbleShooterManager : MonoBehaviour {
        
        public static BubbleShooterManager Instance;
        
        [SerializeField] private TMP_Text ammoAmountText;
        [SerializeField] private TMP_Text bubblePointsText;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject wonPanel;
        private int _bubblePoints;
        public static bool gameOver;

        
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }
        
        private void Start() {
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
            wonPanel.SetActive(false);
            gameOver = false;

        }

        private void Update() {
            if (BubbleList.bubbleList.Count > 0 || gameOver) return;
            WonGame();
        }


        public void IncreaseBubblePoints() {
            _bubblePoints += 100;
            bubblePointsText.text = _bubblePoints.ToString();
        }

        public void AmmoCountDisplay(int currentAmmo) {
            ammoAmountText.text = currentAmmo.ToString();
        }

        public void GameOver() {
            if (gameOver) {
                gameOverPanel.SetActive(true);
                BubbleList.bubbleList.Clear();
            }
        }

        private void WonGame() {
            wonPanel.SetActive(true);
            BubbleList.bubbleList.Clear();
        }

        public void OnRestartClick() {
            SceneManager.LoadScene((int)Scenes.BubbleShooter);
        }

        public void OnQuitClick() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
    }
}
