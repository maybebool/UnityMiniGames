using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake.Scripts {
    public class SnakeController : MonoBehaviour {
        
        [SerializeField] private Transform tailPartsPrefab;
        [SerializeField] private Food food;
        [SerializeField] private Text pointsText;
        private List<Transform> _tailParts;
        private Vector2 _direction = Vector2.right;
        private Vector2 _input;
        private int _points;
        
        private void Start() {
            _tailParts = new List<Transform>();
            _tailParts.Add(transform);
        }

        private void Update() {
            var pressedKey = DetectKeyPress();
    
            switch(pressedKey) {
                case KeyCode.W when _direction.x != 0f :
                    _input = Vector2.up;
                    break;
                case KeyCode.S when _direction.x != 0f:
                    _input = Vector2.down;
                    break;
                case KeyCode.A when _direction.y != 0f:
                    _input = Vector2.left;
                    break;
                case KeyCode.D when _direction.y != 0f:
                    _input = Vector2.right;
                    break;
            }
        }

        private KeyCode DetectKeyPress() {
            if(Input.GetKeyDown(KeyCode.W)) return KeyCode.W;
            if(Input.GetKeyDown(KeyCode.S)) return KeyCode.S;
            if(Input.GetKeyDown(KeyCode.A)) return KeyCode.A;
            if(Input.GetKeyDown(KeyCode.D)) return KeyCode.D;
    
            return KeyCode.None;
        }
        
        private void FixedUpdate() {
            if (_input != Vector2.zero) {
                _direction = _input;
            }

            // Get current position of last tail part  ^1 = last index position
            var lastTailPartPosition = _tailParts[^1].position;
            
            // Move the position of each tail part to the position of the one in front of it (from tail to head)
            for (int i = _tailParts.Count - 1; i > 0; i--) {
                _tailParts[i].position = _tailParts[i - 1].position;
            }

            // If the last tail part has moved, make this position available for spawning food
            if (lastTailPartPosition != _tailParts[^1].position) {
                food.AddFromPossibleFoodPositions(lastTailPartPosition);
            }
            // Move snake head in the direction
            transform.position += new Vector3(_direction.x, _direction.y, 0.0f);
            // Remove the new head position from the possible food positions list
            food.RemoveFromPossibleFoodPositions(_tailParts[0].position);
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Boundries")) {
                SnakeManager.ResetGame();
                transform.position = Vector3.right;
            }else if (other.CompareTag("Food")) {
                GrowSnakeTail();
                PointSetter();
            }
        }

        

        private void GrowSnakeTail() {
            var tailPart = Instantiate(tailPartsPrefab);
            tailPart.position = _tailParts[^1].position;
            _tailParts.Add(tailPart);
            StartCoroutine(ActivateBoxCollider(tailPart.GetComponent<BoxCollider2D>()));
        }

        IEnumerator ActivateBoxCollider(BoxCollider2D coll) {
            yield return new WaitForFixedUpdate();
            coll.enabled = true;
        }

        private void PointSetter() {
            _points++;
            pointsText.text = _points.ToString();
        }
    }
}

