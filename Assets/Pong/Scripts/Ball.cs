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
            AddStartForce();
        }

        private void AddStartForce()
        {
            var x = Random.value < 0.5f ? -1.0f : 1.0f;
            var y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
            var direction = new Vector2(x, y);
            _rigidbody.AddForce(direction * speed);
            

        }
    }
}
