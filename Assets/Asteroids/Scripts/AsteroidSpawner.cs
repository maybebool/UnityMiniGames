using System.Collections;
using UnityEngine;

namespace Asteroids.Scripts {
    public class AsteroidSpawner : MonoBehaviour {
        
        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private float spawnPosXMax, spawnPosYMax;
        private readonly float _spawnInterval = 4f;
        
        private void Start() {
            StartCoroutine(AsteroidSpawning());
        }
        
        // 50/50 chance of positive or negative value
        private float GetRandomPos(float maxPos) {
            return Random.Range(0, 2) == 0 ? maxPos : -maxPos;
        }

        private float GetRandomMaxPos(float maxPos) {
            return Random.Range(-maxPos, maxPos);
        }

        // 50/50 chance of choosing the spawn point depending on the x and y axis
        private Vector2 CreateRandomSpawnPosition() {
            var spawnPos = new Vector2();
            if (Random.Range(0, 2) == 0) {
                spawnPos.x = GetRandomPos(spawnPosXMax);
                spawnPos.y = GetRandomMaxPos(spawnPosYMax);
            }
            else {
                spawnPos.y = GetRandomPos(spawnPosYMax);
                spawnPos.x = GetRandomMaxPos(spawnPosXMax);
            }
            return spawnPos;
        }

        private IEnumerator AsteroidSpawning() {
            while (true) {
                Instantiate(asteroidPrefab, CreateRandomSpawnPosition(), Quaternion.identity).GetComponent<Asteroid>()
                    .AsteroidSetup(true);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }
}