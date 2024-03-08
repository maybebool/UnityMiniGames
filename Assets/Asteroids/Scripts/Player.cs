using UnityEngine;

namespace Asteroids.Scripts {
    public class Player : MonoBehaviour {
        
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float movementDirection = 0f;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float rotationDirection = 0f;
        [SerializeField] private GameObject bulletPrefab;

        public bool screenWrapping = true;
        private Bounds _screenBounds;


        private void Start() {
            var boundaries = GameObject.FindGameObjectsWithTag("Boundries");

            // Convert screen space bounds to world space bounds
            _screenBounds = new Bounds();
            _screenBounds.Encapsulate(Camera.main.ScreenToWorldPoint(Vector3.zero));
            _screenBounds.Encapsulate(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)));
        }

        private void Update() {
            DirectionRotation();
            Movement();
            Shoot();
            rb.angularVelocity = (rotationSpeed * rotationDirection);
            rb.velocity = (transform.up * (movementDirection * movementSpeed));
        }


        private void FixedUpdate() {
            if (screenWrapping) {
                ScreenWrap();
            }
        }


        private void Movement() {
            movementDirection = 0f;

            if (Input.GetKey(KeyCode.W)) {
                movementDirection += 1f;
            }
        }


        private void DirectionRotation() {
            rotationDirection = 0f;

            if (Input.GetKey(KeyCode.A)) {
                rotationDirection += 1f;
            }

            if (Input.GetKey(KeyCode.D)) {
                rotationDirection -= 1f;
            }
        }

        private void Shoot() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }


        // Move to the opposite side of the screen if the player exceeds the bounds
        private void ScreenWrap() {
            if (rb.position.x > _screenBounds.max.x + 0.5f) {
                rb.position = new Vector2(_screenBounds.min.x - 0.5f, rb.position.y);
            }
            else if (rb.position.x < _screenBounds.min.x - 0.5f) {
                rb.position = new Vector2(_screenBounds.max.x + 0.5f, rb.position.y);
            }
            else if (rb.position.y > _screenBounds.max.y + 0.5f) {
                rb.position = new Vector2(rb.position.x, _screenBounds.min.y - 0.5f);
            }
            else if (rb.position.y < _screenBounds.min.y - 0.5f) {
                rb.position = new Vector2(rb.position.x, _screenBounds.max.y + 0.5f);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Asteroid")) {
                AGameManager.Instance.GameOver();
            }
        }
    }
}