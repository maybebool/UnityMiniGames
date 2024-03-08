using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceWars.Scripts {
    public class SWGame_Manager : MonoBehaviour {
        
        public static SWGame_Manager Instance;
        [SerializeField] private Button restartButton;
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
