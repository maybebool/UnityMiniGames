using UnityEngine;

namespace Asteroids.Scripts {
    public class Bullet : MonoBehaviour {
        
        [SerializeField] private Rigidbody2D rbBullet;
        [SerializeField] private float speed = 100f;

        private void Start() {
            rbBullet.velocity = transform.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                return;
            }

            Destroy(gameObject);
        }
    }
}