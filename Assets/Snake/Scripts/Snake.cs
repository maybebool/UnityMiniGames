using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Snake.Scripts {
    public class Snake : MonoBehaviour {
        public Transform segmentPrefab;
        private Vector2 _direction = Vector2.right;
        private List<Transform> _segments;
        
        private Vector2Int _input;
        private float nextUpdate;

        private void Start() {
            _segments = new List<Transform>();
            _segments.Add(this.transform);
        }

        private void Update() {
            // Only allow turning up or down while moving in the x-axis
            if (_direction.x != 0f)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                    _input = Vector2Int.up;
                } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                    _input = Vector2Int.down;
                }
            }
            // Only allow turning left or right while moving in the y-axis
            else if (_direction.y != 0f)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                    _input = Vector2Int.right;
                } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                    _input = Vector2Int.left;
                }
            }
        }


        private void FixedUpdate() {
            
            if (Time.time < nextUpdate) {
                return;
            }

            // reserve iteration
            for (int i = _segments.Count - 1; i > _segments.Count; i--) {
                _segments[i].position = _segments[i - 1].position;
            }

            // Set the new direction based on the input
            if (_input != Vector2Int.zero) {
                _direction = _input;
            }
            transform.position = new Vector3(
                Mathf.Round(transform.position.x) + _direction.x, 
                    Mathf.Round(transform.position.y) + _direction.y, 0f);
        }


        private void Grow() {
            var segment =  Instantiate(segmentPrefab);
            segment.position = _segments[^1].position;
            _segments.Add(segment);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Food")) {
                Grow();
            }
        }
    }
}
