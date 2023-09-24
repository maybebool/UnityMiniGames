using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake.Scripts {
    public class Snake : MonoBehaviour {
        
        [SerializeField] private Transform tailPartsPrefab;
        [SerializeField] private Food food;
        [SerializeField] private Text pointsText;
        
        private List<Transform> _tailParts;
        private Vector2 _direction = Vector2.right;
        private Vector2 input;
        private int points;


        private void Start() {
            _tailParts = new List<Transform>();
            _tailParts.Add(transform);
        }

        private void Update() {
            if (_direction.x != 0f) {
                if (Input.GetKeyDown(KeyCode.W)) {
                    input = Vector2.up;
                }
                else if (Input.GetKeyDown(KeyCode.S)) {
                    input = Vector2.down;
                }
                
            } else if (_direction.y != 0f) {
                if (Input.GetKeyDown(KeyCode.A)) {
                    input = Vector2.left;
                }
                else if (Input.GetKeyDown(KeyCode.D)) {
                    input = Vector2.right;
                }
            }
        }


        private void FixedUpdate() {
            if (input != Vector2.zero) {
                _direction = input;
            }

            var lastTailPartPosition = _tailParts[^1].position;
            // reverse iteration
            for (int i = _tailParts.Count - 1; i > 0; i--) {
                _tailParts[i].position = _tailParts[i - 1].position;
            }

            if (lastTailPartPosition != _tailParts[^1].position) {
                food.AddFromPossibleFoodPositions(lastTailPartPosition);
            }
            
            transform.position += new Vector3(_direction.x, _direction.y, 0.0f);
            food.RemoveFromPossibleFoodPositions(_tailParts[0].position);
        }
        
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Boundries")) {
                ResetGame();
                transform.position = Vector3.right;
            }else if (other.CompareTag("Food")) {
                GrowSnakeTail();
                PointSetter();
            }
        }

        private void ResetGame() {
            SceneManager.LoadScene(11);
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
            points++;
            pointsText.text = points.ToString();
        }
    }
}

