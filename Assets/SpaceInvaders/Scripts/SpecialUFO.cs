using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class SpecialUFO : MonoBehaviour {
        
        [SerializeField] private float speed;
        private Vector3 _leftSide;
        private Vector3 _rightSide;
        private Camera _camera;
        private Vector3 _direction = Vector3.right;

        private void Awake() {
            _camera = Camera.main;
        }

        private void Start() {
            _leftSide = _camera.ViewportToWorldPoint(Vector3.zero);
            _rightSide = _camera.ViewportToWorldPoint(Vector3.right);
        }

        private void Update() {
            transform.position += _direction * (speed * Time.deltaTime);
            if (_direction == Vector3.right && transform.position.x >= _rightSide.x + 10f) {
                Movement();
            }
            else if (_direction == Vector3.left && transform.position.x <= _leftSide.x - 10f) {
                Movement();
            }
        }
        
        private void Movement() {
            _direction = new Vector3(-_direction.x, 0f, 0f);
        }
    }
}
