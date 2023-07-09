using System;
using MineSweeper.Scripts;
using UnityEngine;

namespace FruitNinja.Scripts {
    public class Fruit : MonoBehaviour {


        public GameObject whole;
        public GameObject sliced;


        private Rigidbody _fruitRb;
        private Collider _fruitCollider;

        private void Awake() {
            _fruitCollider = GetComponent<Collider>();
            _fruitRb = GetComponent<Rigidbody>();
        }


        private void Slice(Vector3 direction, Vector3 position, float force) {
            whole.SetActive(false);
            sliced.SetActive(true);
            _fruitCollider.enabled = false;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            var slices = sliced.GetComponentsInChildren<Rigidbody>();
            foreach (var slice in slices) {
                slice.velocity = _fruitRb.velocity;
                slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                var blade = other.GetComponent<Blade>();
                Slice(blade.Direction, blade.transform.position, blade.sliceForce);
            }
        }
    }
}
