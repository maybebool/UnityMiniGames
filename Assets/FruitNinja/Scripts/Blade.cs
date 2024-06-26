using UnityEngine;

namespace FruitNinja.Scripts {
    public class Blade : MonoBehaviour {
        
        public Vector3 Direction { get; private set; }
        public float sliceForce = 5f;
        [SerializeField] private float minSliceVelocity = 0.01f;
        
        private Camera _camera;
        private Collider _bladeCollider;
        private TrailRenderer _trail;
        private bool _slicing;

        private void Awake() {
            _camera = Camera.main;
            _bladeCollider = GetComponent<Collider>();
            _trail = GetComponentInChildren<TrailRenderer>();
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                StartSlicing();
            }
            else if (Input.GetMouseButtonUp(0)) {
                StopSlicing();
            }
            else if (_slicing) {
                ContinueSlicing();
            }
        }

        private void OnEnable() {
            StopSlicing();
        }

        private void OnDisable() {
            StopSlicing();
        }

        private void StartSlicing() {
            var newPos = GetZeroZPosition();
            transform.position = newPos;
            _slicing = true;
            _bladeCollider.enabled = true;
            _trail.enabled = true;
            _trail.Clear();
        }

        private void StopSlicing() {
            _slicing = false;
            _bladeCollider.enabled = false;
            _trail.enabled = false;
        }
        
        private void ContinueSlicing() {
            var newPos = GetZeroZPosition();
            Direction = CalculateDirection(newPos, transform.position);
            _bladeCollider.enabled = IsSwipingFastEnough(Direction, minSliceVelocity);
            transform.position = newPos;
        }

        private Vector3 GetZeroZPosition() {
            var newPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            return newPos;
        }

        private Vector3 CalculateDirection(Vector3 newPos, Vector3 currentPos) {
            return newPos - currentPos;
        }

        private bool IsSwipingFastEnough(Vector3 direction, float velocityThreshold) {
            var velocity = direction.magnitude / Time.deltaTime;
            return velocity > velocityThreshold;
        }
    }
}