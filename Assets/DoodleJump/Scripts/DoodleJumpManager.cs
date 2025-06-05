using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DoodleJump.Scripts {
    public class DoodleJumpManager : MonoBehaviour {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject gameOverPanel;


        private void OnEnable() {
            restartButton.onClick.AddListener(RestartGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(RestartGame);
            quitButton.onClick.RemoveListener(RestartGame);
        }

        private void Update() {
            if (!Player.isAlive) {
                gameOverPanel.SetActive(true);
            }
        }
        
        private void RestartGame() {
            SceneManager.LoadScene((int)Scenes.DoodleJump);
        }

        private void QuitGame() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
    }
}