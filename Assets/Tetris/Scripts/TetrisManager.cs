using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tetris.Scripts {
    public class TetrisManager : MonoBehaviour {
        
        [SerializeField] private Button continueButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject uiPanel;

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
            Time.timeScale = 0;
            uiPanel.SetActive(true);
        }
        
        private void OnClickContinueButton() {
            Time.timeScale = 1;
            uiPanel.SetActive(false);
        }

        private void OnClickQuitButton() {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
    }
}