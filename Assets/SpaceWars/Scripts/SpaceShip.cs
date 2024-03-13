using TMPro;
using UnityEngine;

namespace SpaceWars.Scripts {
    public class SpaceShip : MonoBehaviour {
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float maxHealth;
        [SerializeField] private float upgradeTime;
        [SerializeField] private TMP_Text lifePointsText;
        [SerializeField] private GameObject gameOverPanel;
        
        private float _gunUpgradeTimer;
        private float _moveInputY;
        private Rigidbody2D _rb;
        private float _yMovement;
        private bool _hasUpgrade;
        
        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            lifePointsText.text = "Life: " + maxHealth;
        }

        private void Update() {
            if (_gunUpgradeTimer > 0) {
                _gunUpgradeTimer -= Time.deltaTime;
                if (_gunUpgradeTimer < 0) {
                    _hasUpgrade = false;
                }
            }
            InfiniteScreenTopDown();
            _yMovement += Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            _yMovement = Mathf.Clamp(_yMovement, -8f, 8f) * 0.99f;
            _rb.velocity = new Vector2(0f, _yMovement);
            
            if (Input.GetMouseButtonDown(0)) {
                if (_hasUpgrade) {
                    Instantiate(bulletPrefab, new Vector3(transform.position.x + 1, transform.position.y +1, 0f), Quaternion.identity);
                    Instantiate(bulletPrefab, new Vector3(transform.position.x + 1, transform.position.y -1, 0f), Quaternion.identity);
                }
                else {
                    Instantiate(bulletPrefab, new Vector3(transform.position.x + 2, transform.position.y, 0f), Quaternion.identity);
                }
            }
        }
        
        public void DamageCalculation(float damage) {
            if (maxHealth > 1) {
                maxHealth -= damage;
                lifePointsText.text = "Life: " + maxHealth;
            }
            else {
                Destroy(gameObject);
                Death();
            }
        }
        
        private void InfiniteScreenTopDown() {
            if (transform.position.y >= 12f) {
                transform.position = new Vector3(transform.position.x, -11.9f, 0f);
            }else if (transform.position.y <= -12f) {
                transform.position = new Vector3(transform.position.x, 11.9f, 0f);
            }
        }

        private void Death() {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("GunUpgrade")) {
                _hasUpgrade = true;
                _gunUpgradeTimer = upgradeTime;
                Destroy(other.gameObject);
            }
        }
    }
}
