using System;
using System.Collections;
using UnityEngine;

namespace FruitNinja.Scripts {
    public class Spawner : MonoBehaviour {

        private Collider _spawnArea;
        public GameObject[] FruitPrefabs;
        public float minSpawnDelay = 0.25f;
        public float maxSpawnDelay = 1.25f;
        public float minAngle = -15f;
        public float maxAngle = 15f;
        public float minForce = 18f;
        public float maxForce = 22f;

        public float maxLifeTime = 5f;

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
            
        }
    }
}
