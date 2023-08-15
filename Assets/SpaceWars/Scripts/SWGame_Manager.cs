using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceWars.Scripts {
    public class SWGame_Manager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
            
        private void OnEnable() {
            restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(Restart);
        }
        
        private void Restart() {
            SceneManager.LoadScene(11);
            Time.timeScale = 1;
        }
    }
}
