using System;
using UnityEngine;

namespace Snake.Scripts {
    public class Snake : MonoBehaviour {
        private Vector2 _direction = Vector2.right;
        [SerializeField] private float speed;


        private void Update() {
            if (Input.GetKeyDown(KeyCode.W)) {
                _direction = Vector2.up * (speed * Time.fixedDeltaTime);
            }
            else if (Input.GetKeyDown(KeyCode.S)) {
                _direction = Vector2.down* (speed * Time.fixedDeltaTime);
            }
            else if (Input.GetKeyDown(KeyCode.A)) {
                _direction = Vector2.left* (speed * Time.fixedDeltaTime);
            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                _direction = Vector2.right* (speed * Time.fixedDeltaTime);
            }
        }


        private void FixedUpdate() {
            transform.position =
                new Vector3(Mathf.Round(transform.position.x) + _direction.x, 
                    Mathf.Round(transform.position.y) + _direction.y, 0f);
        }
    }
}
