using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong.Scripts {
    public class Ball : MonoBehaviour {
        private Rigidbody2D _rb;
        public float speed = 200f;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            ResetPosition();
            AddStartForce();
        }

        public void AddStartForce() {
            var x = Random.value < 0.5f ? -1.0f : 1.0f;
            var y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
            var direction = new Vector2(x, y);
            _rb.AddForce(direction * speed);
        }

        public void AddForce(Vector2 force) {
            _rb.AddForce(force);
        }

        public void ResetPosition() {
            _rb.position = Vector2.zero;
            _rb.velocity = Vector2.zero;
        }
    }
}