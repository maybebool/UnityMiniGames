using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public float speed = 200f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            ResetPosition();
            AddStartForce();
        }

        public void AddStartForce()
        {
            var x = Random.value < 0.5f ? -1.0f : 1.0f;
            var y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
            var direction = new Vector2(x, y);
            _rigidbody.AddForce(direction * speed);
        }

        public void AddForce(Vector2 force) {
            _rigidbody.AddForce(force);
        }

        public void ResetPosition()
        {
            _rigidbody.position = Vector2.zero;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
