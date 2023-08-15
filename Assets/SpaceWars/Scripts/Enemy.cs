using System;
using SpaceWars.Scripts;
using TMPro;
using UnityEngine;

namespace SpaceGame.Scripts {
    public class Enemy : MonoBehaviour {

        [SerializeField] private float maxHealth;
        [SerializeField] private float movementSpeed;

        private Rigidbody2D rb;
        private float lifePoints;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            
        }

        private void Start() {
            rb.velocity = new Vector2(-movementSpeed, 0f);
            
        }

        public void DamageCalculation(float damage) {
            if (maxHealth > 1) {
                maxHealth -= damage;
            }
            else {
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
