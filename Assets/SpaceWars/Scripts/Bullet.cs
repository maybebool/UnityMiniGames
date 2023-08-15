using System;
using UnityEngine;

namespace SpaceGame.Scripts {
    public class Bullet : MonoBehaviour {
        
        
        [SerializeField] private float bulletSpeed;

        private void Update() {
            transform.position += new Vector3(bulletSpeed, 0f, 0f) * Time.deltaTime;
            
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Enemy")) {
                other.GetComponent<Enemy>().DamageCalculation(1);
                Destroy(gameObject);
            }
        }
    }
}
