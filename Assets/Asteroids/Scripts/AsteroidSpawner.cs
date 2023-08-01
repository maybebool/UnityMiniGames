using System.Collections;
using UnityEngine;

namespace Asteroids.Scripts {
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private float spawnPosXMax, spawnPosYMax;
        private float _spawnInterval = 4f;


        private void Start() {
            StartCoroutine(AsteroidSpawning());
        }


        private Vector2 CreateRandomSpawnPosition() {
            var spawnPos = new Vector2();
            if (Random.Range(0,2) == 0) {
                if (Random.Range(0,2) == 0) {
                    spawnPos.x = spawnPosXMax;
                }
                else {
                    spawnPos.x = -spawnPosXMax;
                }

                spawnPos.y = Random.Range(-spawnPosYMax, spawnPosYMax);
            }
            else {
                if (Random.Range(0,2) == 0) {
                    spawnPos.y = spawnPosYMax;
                }
                else {
                    spawnPos.y = -spawnPosYMax;
                }
                spawnPos.x = Random.Range(-spawnPosXMax, spawnPosXMax);
            }

            return spawnPos;
        }

        private IEnumerator AsteroidSpawning() {
            
            while (true) {
                Instantiate(asteroidPrefab, CreateRandomSpawnPosition(), Quaternion.identity).GetComponent<Asteroid>().AsteroidSetup(true);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }
}
