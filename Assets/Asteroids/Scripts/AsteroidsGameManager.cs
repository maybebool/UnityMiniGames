using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.Scripts {
    public class AsteroidsGameManager : MonoBehaviour {
        
        public static AsteroidsGameManager Instance;
        [SerializeField] private TMP_Text asteroidPoints;
        private int _points;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        public static void GameOver() {
            SceneManager.LoadScene((int)Scenes.Asteroids);
        }

        public void PointCounter() {
            _points += 10;
            asteroidPoints.text = _points.ToString();
        }
    }
}