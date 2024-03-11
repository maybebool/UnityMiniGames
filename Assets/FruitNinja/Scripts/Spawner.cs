using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace FruitNinja.Scripts {
    public class Spawner : MonoBehaviour {
        [SerializeField] private GameObject[] fruitPrefabs;
        [SerializeField] private GameObject bombPrefab;
        [SerializeField] private float maxLifeTime = 5f;
        [Range(0f, 1f)] [SerializeField] private float bombChance = 0.05f;
        [SerializeField] private float minAngle = -15f;
        [SerializeField] private float maxAngle = 15f;
        [SerializeField] private float minForce = 18f;
        [SerializeField] private float maxForce = 22f;
        [SerializeField] private float minSpawnDelay = 0.25f;
        [SerializeField] private float maxSpawnDelay = 1.25f;

        private Collider _spawnFieldCollider;

        private void Awake() {
            _spawnFieldCollider = GetComponent<Collider>();
        }

        private void OnEnable() {
            StartCoroutine(StartSpawnCycle());
        }

        private void OnDisable() {
            StopAllCoroutines();
        }
        
        private IEnumerator StartSpawnCycle() {
            yield return new WaitForSeconds(2);
            while (enabled) {
                var prefab = GetRandomPrefab();
                var pos = GetRandomPositionWithinBounds();

                var rot = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
                var fruit = Instantiate(prefab, pos, rot);

                FruitNinjaGameManager.spawnedSceneObjects.Add(fruit);
                Destroy(fruit, maxLifeTime);
                ApplyForceToFruit(fruit);
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            }
        }

        private GameObject GetRandomPrefab() {
            var prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            if (Random.value < bombChance) {
                prefab = bombPrefab;
            }

            return prefab;
        }

        private Vector3 GetRandomPositionWithinBounds() {
            var pos = new Vector3();
            pos.x = Random.Range(_spawnFieldCollider.bounds.min.x, _spawnFieldCollider.bounds.max.x);
            pos.y = Random.Range(_spawnFieldCollider.bounds.min.y, _spawnFieldCollider.bounds.max.y);
            pos.z = Random.Range(_spawnFieldCollider.bounds.min.z, _spawnFieldCollider.bounds.max.z);
            return pos;
        }

        private void ApplyForceToFruit(GameObject fruit) {
            var force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);
        }
    }
}