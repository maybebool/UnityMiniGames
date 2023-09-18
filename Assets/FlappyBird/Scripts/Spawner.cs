using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FlappyBird.Scripts {
    public class Spawner : MonoBehaviour {
        public GameObject prefab;
        public float spawnRate = 1;
        public float minHight = -1;
        public float maxHeight = 1f;

        private void OnEnable() {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }


        private void OnDisable() {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn() {
            var pipes = Instantiate(prefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHight, maxHeight);
        }
    }
}