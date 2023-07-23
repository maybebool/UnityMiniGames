using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.Scripts {
    public class AGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text asteroidPoints;
        public static AGameManager Instance;
        private int _points;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        public void GameOver() {
            SceneManager.LoadScene(9);
        }

        public void PointCounter() {
            _points += 10;
            asteroidPoints.text = _points.ToString();
        }
    }
}
