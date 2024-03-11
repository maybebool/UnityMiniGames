using System;
using System.Collections;
using System.Collections.Generic;
using Menu;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FruitNinja.Scripts {
    public class FruitNinjaGameManager : MonoBehaviour {

        public static readonly List<GameObject> spawnedSceneObjects = new();
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Image fadeImage;
        
        private int _score;
        private Blade _blade;
        private Spawner _spawner;
        
        private void Awake() {
            _blade = FindObjectOfType<Blade>();
            _spawner = FindObjectOfType<Spawner>();
        }

        private void Start() {
            NewGame();
        }


        private void OnEnable() {
            restartButton.onClick.AddListener(RestartGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(RestartGame);
            quitButton.onClick.RemoveListener(QuitGame);
        }

        private void RestartGame() {
            SceneManager.LoadScene((int)Scenes.FruitNinja);
        }
        
        private void QuitGame() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }
        
        

        private void NewGame() {
            
            Time.timeScale = 1f;
            ClearScene();
            _blade.enabled = true;
            _spawner.enabled = true;
            _score = 0;
            scoreText.text = _score.ToString();
        }
        
        private void ClearScene() {
            foreach (var sceneObject in spawnedSceneObjects) {
                Destroy(sceneObject.gameObject);
            }
            spawnedSceneObjects.Clear();
        }

        public void IncreaseScore(int amount) {
            _score += amount;
            scoreText.text = _score.ToString();
        }

        public void Explode() {
            _blade.enabled = false;
            _spawner.enabled = false;
            StartCoroutine(ExplosionEffect());
            gameOverPanel.SetActive(true);
        }

        private IEnumerator ExplosionEffect() {
            yield return LerpOverTime(Color.clear, Color.white, 0.5f);
            yield return new WaitForSecondsRealtime(1f);
            NewGame();
            yield return LerpOverTime(Color.white, Color.clear, 0.5f);
        }

        private IEnumerator LerpOverTime(Color startColor, Color endColor, float duration) {
            var elapsed = 0f;
            while (elapsed < duration) {
                var t = Mathf.Clamp01(elapsed / duration);
                fadeImage.color = Color.Lerp(startColor, endColor, t);

                Time.timeScale = 1f - t;
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
}
