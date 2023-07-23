using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleShooter.Scripts {
    public class BSGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text ammoAmountText;
        [SerializeField] private TMP_Text bubblePointsText;
        [SerializeField] private GameObject gameOverPanel;
        private int _bubblePoints;

        public static BSGameManager Instance;
        
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        private void Start() {
            gameOverPanel.SetActive(false);
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

        public void OnRestartClick() {
            SceneManager.LoadScene(10);
        }

        public void OnQuitClick() {
            Application.Quit();
        }
    }
}
