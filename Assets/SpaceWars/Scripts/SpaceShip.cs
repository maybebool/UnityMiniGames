using UnityEngine;

namespace SpaceGame.Scripts {
    public class SpaceShip : MonoBehaviour {
        [SerializeField] private float movementSpeed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Vector3 cannonPivot;
        private float moveInputY;
        private Rigidbody2D rb;
        private float yMovement;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            yMovement += Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            yMovement = Mathf.Clamp(yMovement, -8f, 8f) * 0.99f;
            rb.velocity = new Vector2(0f, yMovement);
            
            if (Input.GetMouseButtonDown(0)) {
                Instantiate(bulletPrefab, new Vector3(transform.position.x + 2, transform.position.y, 0f), Quaternion.identity);
            }
        }
    }
}
