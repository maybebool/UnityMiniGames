using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodleJump.Scripts {
    public class Player : MonoBehaviour {

        public static bool isAlive;
        [SerializeField] private Camera camera;
        [SerializeField] private float normalBounceFactor;
        [SerializeField] private float specialPlatformBounceFactor;
        [SerializeField] private float movementSpeed;
        [SerializeField] private Text scoreText;
        [SerializeField] private float scrollSpeed;
        [SerializeField] private List<Transform> platforms = new();
        private float _score;
        private float _moveInput;
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;


        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
        
        }

        private void Start() {
            isAlive = true;
        }

        private void Update() {
            FlipSpriteBasedOnDirection();
            InfiniteScreenLeftRight();
            _moveInput = Input.GetAxis("Horizontal");

            if (transform.position.y >= 0 ) {
                _score += 0.1f;
        
                transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);
                for (int i = 0; i < platforms.Count; i++) {
                    platforms[i].position += Vector3.down * (scrollSpeed * Time.deltaTime);
                }
            }

            scoreText.text = "Score: " + Mathf.Round(_score);
        }
        
        private void FixedUpdate() {
            _rb.velocity = new Vector2(_moveInput * movementSpeed, _rb.velocity.y);
        }

        private void FlipSpriteBasedOnDirection() {
            if (_moveInput < 0) {
                _sr.flipX = true;
            }else if (_moveInput > 0) {
                _sr.flipX = false;
            }
        }

        private void InfiniteScreenLeftRight() {
            if (transform.position.x >= 5.6f) {
                transform.position = new Vector3(-5.58f, transform.position.y, 0f);
            }else if (transform.position.x <= -5.6f) {
                transform.position = new Vector3(5.58f, transform.position.y, 0f);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (_rb.velocity.y <= 0) {
                if (other.CompareTag("NormalPlatform")) {
                    _rb.velocity = Vector2.zero;
                    _rb.velocity += (Vector2.up * normalBounceFactor);
                }
                if (other.CompareTag("SpringPlatform")) {
                    _rb.velocity = Vector2.zero;
                    _rb.velocity += (Vector2.up * specialPlatformBounceFactor);
                }
                if (other.CompareTag("Death")) {
                    isAlive = false;
                }
            }
        }
    }
}
    
    
    
