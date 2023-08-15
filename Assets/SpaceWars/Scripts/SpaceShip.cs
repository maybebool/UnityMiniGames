using TMPro;
using UnityEngine;

namespace SpaceWars.Scripts {
    public class SpaceShip : MonoBehaviour {
        [SerializeField] private float movementSpeed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float maxHealth;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private GameObject gameOverPanel;
        
        private float _moveInputY;
        private Rigidbody2D _rb;
        private float _yMovement;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            lifePointsText.text = "Life: " + maxHealth;
        }

        private void Update() {
            InfiniteScreenTopDown();
            _yMovement += Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            _yMovement = Mathf.Clamp(_yMovement, -8f, 8f) * 0.99f;
            _rb.velocity = new Vector2(0f, _yMovement);
            
            if (Input.GetMouseButtonDown(0)) {
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 2, transform.position.y, 0f), Quaternion.identity);
            }
        }
        
        public void DamageCalculation(float damage) {
            if (maxHealth > 1) {
                maxHealth -= damage;
                lifePointsText.text = "Life: " + maxHealth;
            }
            else {
                Destroy(gameObject);
                GameOver();
            }
        }
        
        private void InfiniteScreenTopDown() {
            if (transform.position.y >= 12f) {
                transform.position = new Vector3(transform.position.x, -11.9f, 0f);
            }else if (transform.position.y <= -12f) {
                transform.position = new Vector3(transform.position.x, 11.9f, 0f);
            }
        }

        private void GameOver() {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
