using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceWars.Scripts {
    public class Spawner : MonoBehaviour {

        [SerializeField] private float maxPos;
        [SerializeField] private Vector2 spawnPos;
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private float enemyInterval;
        [SerializeField] private float gunUpgradeInterval;
        [SerializeField] private GameObject gunUpgradePrefab;
        
        private void Start() {
            StartCoroutine(EnemySpawner());
            StartCoroutine(GunUpgradeSpawner());
        }

        private Vector2 CalculateRandomSpawnPos() {
            spawnPos.y = Random.Range(-maxPos, maxPos);
            return spawnPos;
        }

        private IEnumerator EnemySpawner() {
            while (true) {
                Instantiate(enemies[Random.Range(0, enemies.Length)], CalculateRandomSpawnPos(), Quaternion.identity);
                yield return new WaitForSeconds(enemyInterval);
            }
        }

        private IEnumerator GunUpgradeSpawner() {
            while (true) {
                Instantiate(gunUpgradePrefab, CalculateRandomSpawnPos(), Quaternion.identity);
                yield return new WaitForSeconds(gunUpgradeInterval);
            }
        }
    }
}
