using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Player player;
        public Text scoreText;
        public GameObject playButton;
        public Button playingButton;
        public GameObject gameOver;
        
        private int _score;

        private void OnEnable() {
            playingButton.onClick.AddListener(Play);
        }

        private void OnDisable() {
            playingButton.onClick.RemoveListener(Play);
        }

        private void Awake() {
            Application.targetFrameRate = 60;
            Pause();
        }

        public void Play() {
            _score = 0;
            scoreText.text = _score.ToString();
            playButton.SetActive(false);
            gameOver.SetActive(false);

            Time.timeScale = 1f;
            player.enabled = true;
            Pipes[] pipes = FindObjectsOfType<Pipes>();
            foreach (var t in pipes)
            {
                Destroy(t.gameObject);
            }

        }

        public void Pause() {
            Time.timeScale = 0f;
            player.enabled = false;
        }

        public void GameOver() {
            gameOver.SetActive(true);
            playButton.SetActive(true);
            Pause();
            Debug.Log("game over");
        }

        public void IncreaseScore() {
            _score++;
            scoreText.text = _score.ToString();
            Debug.Log($"Score" + _score);
        }
    }
}
