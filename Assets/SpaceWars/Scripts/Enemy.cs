using UnityEngine;

namespace SpaceWars.Scripts {
    public class Enemy : MonoBehaviour {

        [SerializeField] private float maxHealth;
        [SerializeField] private float movementSpeed;
        private Rigidbody2D _rb;


        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            
        }

        private void Start() {
            _rb.velocity = new Vector2(-movementSpeed, 0f);
        }

        public void DamageCalculation(float damage) {
            if (maxHealth > 1) {
                maxHealth -= damage;
            }
            else {
                SWGame_Manager.Instance.CountPoint();
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Death")) {
                Destroy(gameObject);
            }

            if (other.CompareTag("Player")) {
                other.GetComponent<SpaceShip>().DamageCalculation(1);
                Destroy(gameObject);
            }
        }
    }
}
