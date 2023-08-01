using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private GameObject bulletPrefab;
        private Vector3 _leftSide;
        private Vector3 _rightSide;
        private Bullet _bullet;
        public bool bulletOnTheField;

        public static Player Instance;
        private Camera _camera;


        private void Awake() {
            _camera = Camera.main;


            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        private void Start() {
            _leftSide = _camera.ViewportToWorldPoint(Vector3.zero);
            _rightSide = _camera.ViewportToWorldPoint(Vector3.right);
        }


        private void Update() {
            var pos = transform.position;
            if (Input.GetKey(KeyCode.A)) {
                pos.x -= speed * Time.deltaTime;
            }
            
            if (Input.GetKey(KeyCode.D)) {
                pos.x += speed * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                ShootBullet();
            }
            
            pos.x = Mathf.Clamp(pos.x, _leftSide.x + 2f, _rightSide.x - 2f);
            transform.position = pos;
        }


        private void ShootBullet() {
            if (bulletOnTheField) return;
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().IsPlayer = true;
            bulletOnTheField = true;
        }
    }
}
