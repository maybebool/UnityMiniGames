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
        }

        private void Update() {
            if (BubbleList.bubbleList.Count >= 1) return;
            WonGame();
            BubbleList.bubbleList.Clear();
        }


        public void IncreaseBubblePoints() {
            _bubblePoints += 100;
            bubblePointsText.text = _bubblePoints.ToString();
        }

        public void AmmoCountDisplay(int currentAmmo) {
            ammoAmountText.text = currentAmmo.ToString();
        }

        public void GameOver() {
            gameOverPanel.SetActive(true);
        }

        private void WonGame() {
            wonPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void OnRestartClick() {
            SceneManager.LoadScene((int)Scenes.BubbleShooter);
        }

        public void OnQuitClick() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
    }
}
