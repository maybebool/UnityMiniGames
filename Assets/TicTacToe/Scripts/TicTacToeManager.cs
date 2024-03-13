using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe.Scripts {
    public class TicTacToeManager : MonoBehaviour {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;


        private void OnEnable() {
            restartButton.onClick.AddListener(OnClickRestartButton);
            quitButton.onClick.AddListener(OnClickQuitButton);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(OnClickRestartButton);
            quitButton.onClick.RemoveListener(OnClickQuitButton);
        }


        private void OnClickRestartButton() {
            SceneManager.LoadScene((int)Scenes.TicTacToe);
        }
        
        private void OnClickQuitButton() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
        
    }
}
