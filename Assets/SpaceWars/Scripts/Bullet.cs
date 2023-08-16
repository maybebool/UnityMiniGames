using UnityEngine;

namespace SpaceWars.Scripts {
    public class Bullet : MonoBehaviour {
        
        [SerializeField] private float bulletSpeed;
        public bool isBulletFromEnemy;

        private void Update() {
            if (!isBulletFromEnemy) {
                transform.position += new Vector3(bulletSpeed, 0f, 0f) * Time.deltaTime;
            }
            else {
                transform.position += new Vector3(-bulletSpeed, 0f, 0f) * Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Enemy") && !isBulletFromEnemy) {
                other.GetComponent<Enemy>().DamageCalculation(1);
                Destroy(gameObject);
            }
            if (other.CompareTag("Boundries")) {
                Destroy(gameObject);
                
            }
            if (other.CompareTag("Player") && isBulletFromEnemy) {
                other.GetComponent<SpaceShip>().DamageCalculation(1);
                Destroy(gameObject);
            }
        }
    }
}
