using System;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SpaceInvaders.Scripts {
    public class SpaceInvadersManager : MonoBehaviour {
        
        public static SpaceInvadersManager Instance;
        
        [SerializeField] private GameObject uiPanel;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private TMP_Text wonText;
        [SerializeField] private TMP_Text gameOverText;
        [SerializeField] private TMP_Text pointText;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private int playerLifePoints;

        private int _points;

        private void Start() {
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

        private void OnEnable() {
            restartButton.onClick.AddListener(OnRestartClick);
            quitButton.onClick.AddListener(OnQuitClick);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(OnRestartClick);
            quitButton.onClick.AddListener(OnQuitClick);
        }


        public void UIPanelScreen() {
            Time.timeScale = 0;
            uiPanel.SetActive(true);
            if (playerLifePoints <= 0 ) {
                gameOverText.gameObject.SetActive(true);
            }
            if (_points >= 100) {
                wonText.gameObject.SetActive(true);
            }
        }
        
        private void OnRestartClick() {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)Scenes.SpaceInvaders);
        }

        private void OnQuitClick() {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
        
        

        public void PointCounter(int amountOfPoints) {
            _points += amountOfPoints;
            pointText.text = _points.ToString();
        }

        public void PlayerLifeSetter() {
            if (playerLifePoints > 0 + 1) {
                playerLifePoints--;
            }
            else {
                UIPanelScreen();
            }
            lifePointsText.text = playerLifePoints.ToString();
        }
    }
}