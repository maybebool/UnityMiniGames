using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FruitNinja.Scripts {
    public class Spawner : MonoBehaviour {
        // TODO make serialized fields
        public GameObject[] FruitPrefabs;
        public GameObject bombPrefab;
        [Range(0f,1f)] public float bombChance = 0.05f;
        public float minSpawnDelay = 0.25f;
        public float maxSpawnDelay = 1.25f;
        public float minAngle = -15f;
        public float maxAngle = 15f;
        public float minForce = 18f;
        public float maxForce = 22f;
        public float maxLifeTime = 5f;
        
        private Collider _spawnArea;

        private void Awake() {
            _spawnArea = GetComponent<Collider>();
        }

        private void OnEnable() {
            StartCoroutine(Spawn());
        }

        private void OnDisable() {
            StopAllCoroutines();
        }

        private IEnumerator Spawn() {

            yield return new WaitForSeconds(2);
            while (enabled) {

                var prefab = FruitPrefabs[Random.Range(0, FruitPrefabs.Length)];
                if (Random.value < bombChance) {
                    prefab = bombPrefab;
                }
                var pos = new Vector3();
                pos.x = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
                pos.y = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);
                pos.z = Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z);

                var rot = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
                var fruit =  Instantiate(prefab, pos,rot);
                Destroy(fruit, maxLifeTime);
                var force = Random.Range(minForce, maxForce);
                fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            }
        }
    }
}
