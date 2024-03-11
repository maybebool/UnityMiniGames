using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Scripts {
    public class FruitNinjaGameManager : MonoBehaviour {

        public static List<GameObject> spawnedSceneObjects = new();
        public TMP_Text scoreText;
        public Image fadeImage;
        
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

        private void NewGame() {
            
            Time.timeScale = 1f;
            ClearScene();
            _blade.enabled = true;
            _spawner.enabled = true;
            _score = 0;
            scoreText.text = _score.ToString();
        }

        // private void ClearScene() {
        //     var fruits = FindObjectsOfType<Fruit>();
        //
        //     foreach (var fruit in fruits) {
        //         Destroy(fruit.gameObject);
        //     }
        //     
        //     var bombs = FindObjectsOfType<Bomb>();
        //
        //     foreach (var bomb in bombs) {
        //         Destroy(bomb.gameObject);
        //     }
        // }
        
        
        // private void ClearScene() 
        // {
        //     DestroyObjectsOfType<Fruit>();
        //     DestroyObjectsOfType<Bomb>();
        // }
        //
        // private void DestroyObjectsOfType<T>() where T: MonoBehaviour
        // {
        //     var objects = FindObjectsOfType<T>();
        //     foreach (var obj in objects)
        //     {
        //         Destroy(obj.gameObject);
        //     }
        // }
        
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
            StartCoroutine(ExplodeSequence());
        }

        private IEnumerator ExplodeSequence() {
            var elapsed = 0f;
            var duration = 0.5f;

            while (elapsed < duration) {

                var t = Mathf.Clamp01(elapsed / duration);
                fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

                Time.timeScale = 1f - t;
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }

            yield return new WaitForSecondsRealtime(1f);
            NewGame();

            elapsed = 0f;
            
            while (elapsed < duration) {

                var t = Mathf.Clamp01(elapsed / duration);
                fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

                Time.timeScale = 1f - t;
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
}
