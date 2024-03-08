using UnityEngine;

namespace Breakout.Scripts {
    public class BreakoutBall : MonoBehaviour {
        
        [SerializeField] private float speed;
        [SerializeField] private BreakoutManager gm;
        private Rigidbody _rb;
        private Vector3 _velocity;


        private void Awake() {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void Start() {
            Invoke(nameof(StartBall), 2);
        }

        private void StartBall() {
            _velocity = new Vector3(Random.Range(-1.0f, 1.0f), -1.0f, 0f).normalized * speed;
            _rb.velocity = _velocity;
        }

        private void OnCollisionEnter(Collision other) {
            if (other.gameObject.CompareTag("Paddel") || other.gameObject.CompareTag("Wall") ||
                other.gameObject.CompareTag("Brick")) {
                var normal = other.contacts[0].normal;
                _velocity = (2 * (Vector3.Dot(_velocity, normal)) * normal - _velocity) * -1;
                _rb.velocity = _velocity;

                if (other.gameObject.CompareTag("Brick")) {
                    gm.Counter();
                    Destroy(other.gameObject);
                }
            }
            
            if (other.gameObject.CompareTag("Death")) {
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                gm.Death();
                Invoke(nameof(StartBall), 1);
            }
        }
    }
}