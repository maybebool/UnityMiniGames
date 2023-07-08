using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breakout.Scripts {
    public class BreakoutManager : MonoBehaviour
    {
        [SerializeField] private int lifePoints = 3;
        [SerializeField] private int counter = 3;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private TMP_Text pointCounter;
        [SerializeField] private Canvas gameOver;


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

        private void GameOver() {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
        }

        public void Restart() {
            SceneManager.LoadScene("Breakout");
            Time.timeScale = 1;
        }
    }
}
