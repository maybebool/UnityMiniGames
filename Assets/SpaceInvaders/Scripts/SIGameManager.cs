using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaders.Scripts {
    public class SIGameManager : MonoBehaviour {
        
        public static SIGameManager Instance;
        
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TMP_Text pointText;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private int playerLifePoints;

        private int _points;

        private void Start() {
            Time.timeScale = 1;
            lifePointsText.text = playerLifePoints.ToString();
        }

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        public void GameOverScreen() {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        
        public void OnRestartClick() {
            SceneManager.LoadScene(3);
        }

        public void PointCounter(int amountOfPoints) {
            _points += amountOfPoints;
            pointText.text = _points.ToString();
        }

        public void PlayerLifeSetter() {
            if (playerLifePoints > 1) {
                playerLifePoints--;
            }
            else {
                GameOverScreen();
            }
            lifePointsText.text = playerLifePoints.ToString();
        }
    }
}