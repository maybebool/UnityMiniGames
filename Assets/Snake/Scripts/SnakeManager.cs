using System;
using Menu;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake.Scripts {
    public class SnakeManager : MonoBehaviour {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject uiPanel;


        private void Start() {
            Time.fixedDeltaTime = 0.08f;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnClickPauseGame();
            }
        }

        private void OnEnable() {
            continueButton.onClick.AddListener(OnClickContinueGame);
            quitButton.onClick.AddListener(OnClickQuitGame);
        }

        private void OnDisable() {
            continueButton.onClick.RemoveListener(OnClickContinueGame);
            quitButton.onClick.RemoveListener(OnClickQuitGame);
        }


        public static void ResetGame() {
            SceneManager.LoadScene((int)Scenes.Snake);
        }


        private void OnClickContinueGame() {
            uiPanel.SetActive(false);
            Time.timeScale = 1;
        }

        private void OnClickPauseGame() {
            uiPanel.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnClickQuitGame() {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }

    }
}