using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids.Scripts {
    public class AsteroidsGameManager : MonoBehaviour {
        
        public static AsteroidsGameManager Instance;
        [SerializeField] private TMP_Text asteroidPoints;
        [SerializeField] private GameObject uiPanel;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button quitButton;
        private int _points;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        private void OnEnable() {
            continueButton.onClick.AddListener(OnCLickContinueButton);
            quitButton.onClick.AddListener(OnClickQuitButton);
        }

        private void OnDisable() {
            continueButton.onClick.RemoveListener(OnCLickContinueButton);
            quitButton.onClick.RemoveListener(OnClickQuitButton);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnClickPauseGame();
            }
        }

        private void OnCLickContinueButton() {
            Time.timeScale = 1;
            uiPanel.SetActive(false);
        }

        private void OnClickQuitButton() {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }

        private void OnClickPauseGame() {
            Time.timeScale = 0;
            uiPanel.SetActive(true);
        }
        

        public static void GameOver() {
            SceneManager.LoadScene((int)Scenes.Asteroids);
        }

        public void PointCounter() {
            _points += 10;
            asteroidPoints.text = _points.ToString();
        }
    }
}