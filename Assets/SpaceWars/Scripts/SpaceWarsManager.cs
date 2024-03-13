using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceWars.Scripts {
    public class SpaceWarsManager : MonoBehaviour {
        
        public static SpaceWarsManager Instance;
        
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private TMP_Text pointsText;
        
        private int _points;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }
        
        public void CountPoint() {
            _points++;
            pointsText.text = _points.ToString();
        }
        private void OnEnable() {
            restartButton.onClick.AddListener(OnClickRestartButton);
            quitButton.onClick.AddListener(OnClickQuitButton);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(OnClickRestartButton);
            quitButton.onClick.RemoveListener(OnClickQuitButton);
        }
        
        private void OnClickRestartButton() {
            SceneManager.LoadScene(11);
            Time.timeScale = 1;
        }

        private void OnClickQuitButton() {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
    }
}
