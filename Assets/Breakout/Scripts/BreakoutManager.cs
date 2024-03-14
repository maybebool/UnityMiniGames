using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Breakout.Scripts {
    public class BreakoutManager : MonoBehaviour {
        
        [SerializeField] private int lifePoints = 3;
        [SerializeField] private int counter = 3;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private TMP_Text pointCounter;
        [SerializeField] private GameObject uiPanel;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;

        private void OnEnable() {
            restartButton.onClick.AddListener(Restart);
            quitButton.onClick.AddListener(Quit);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(Restart);
            quitButton.onClick.AddListener(Quit);
        }

        public void Counter() {
            counter += 100;
            pointCounter.text = counter.ToString();
            if (counter >= 6000) {
                GameOver();
            }
        }


        public void Death() {
            if (lifePoints > 1) {
                lifePoints--;
            }
            else {
                GameOver();
            }

            lifePointsText.text = lifePoints.ToString();
        }
        
        private void Restart() {
            SceneManager.LoadScene((int)Scenes.Breakout);
            Time.timeScale = 1;
        }

        private void Quit() {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }

        private void GameOver() {
            Time.timeScale = 0;
            uiPanel.gameObject.SetActive(true);
        }

    }
}