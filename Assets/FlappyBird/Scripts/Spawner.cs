using UnityEngine;
using Random = UnityEngine.Random;

namespace FlappyBird.Scripts {
    public class Spawner : MonoBehaviour {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float spawnRate = 1;
        [SerializeField] private float minHeight = -1;
        [SerializeField] private float maxHeight = 1f;

        private void OnEnable() {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }
        
        private void OnDisable() {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn() {
            var pipes = Instantiate(prefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        }
    }
}