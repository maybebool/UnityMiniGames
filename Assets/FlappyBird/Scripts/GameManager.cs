using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyBird.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highScoreText;
        [SerializeField] private GameObject newHighScoreText;
        [SerializeField] private Button restartButton;
        private bool _hasPressedStart;
        private int _score;


        private void OnEnable() {
            restartButton.onClick.AddListener(OnClickRestart);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(OnClickRestart);
        }

        private void Start() {
            Time.timeScale = 0;
        }


        private void Update() {
            if (Input.anyKey && !_hasPressedStart) {
                Time.timeScale = 1;
                _hasPressedStart = true;
            }
        }


        public void GameOver() {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);

            if (_score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore", _score);
                newHighScoreText.SetActive(true);
            }

            highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        }

        public void OnClickRestart() {
            SceneManager.LoadScene(2);
        }


        public void IncreaseScore() {
            _score++;
            scoreText.text = _score.ToString();
        }
    }
}
