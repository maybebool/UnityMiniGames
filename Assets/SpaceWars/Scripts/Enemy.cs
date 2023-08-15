using System;
using UnityEngine;

namespace SpaceGame.Scripts {
    public class Enemy : MonoBehaviour {

        [SerializeField] private float maxHealth;
        [SerializeField] private float movementSpeed;

        private Rigidbody2D rb;

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
    }
}
