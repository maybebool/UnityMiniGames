using System.Collections;
using UnityEngine;

namespace SpaceWars.Scripts {
    public class Enemy : MonoBehaviour {

        [SerializeField] private float maxHealth;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float fireRate;
        [SerializeField] private GameObject bulletPrefab;
        private Rigidbody2D _rb;

        
        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            
        }

        private void Start() {
            _rb.velocity = new Vector2(-movementSpeed, 0f);
            StartCoroutine(BulletInstantiation());
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

        private IEnumerator BulletInstantiation() {
            var bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x - 2, transform.position.y, 0f),
                Quaternion.identity).GetComponent<Bullet>();
            bullet.isBulletFromEnemy = true;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            yield return new WaitForSeconds(fireRate);
            StartCoroutine(BulletInstantiation());
        } 
         
    }
}
