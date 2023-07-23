using UnityEngine;
using Random = UnityEngine.Random;

namespace FlappyBird.Scripts
{
    public class Pipes : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        [SerializeField] private float xOffset = 10f;
        [SerializeField] private float yOffset;
        [SerializeField] private bool isFirstPipe;
        
        private void Start() {
            if (isFirstPipe) return;
            var rnd = Random.Range(-yOffset, yOffset);
            transform.position = new Vector3(transform.position.x, rnd, 0);
        }

        private void Update() {
            
            transform.position += Vector3.left * (Time.deltaTime * speed);
            
            if (transform.position.x <= -xOffset) {
                var rnd = Random.Range(-yOffset, yOffset);
                transform.position = new Vector3(xOffset, rnd, 0);
            }
        }
    }
}
