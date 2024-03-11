using UnityEngine;

namespace FruitNinja.Scripts {
    public class Fruit : MonoBehaviour {
        
        [SerializeField] private GameObject whole;
        [SerializeField] private GameObject sliced;
        [SerializeField] private int points = 1;
        
        private Rigidbody _fruitRb;
        private Collider _fruitCollider;
        private ParticleSystem _juiceParticleEffect;

        private void Awake() {
            _fruitCollider = GetComponent<Collider>();
            _fruitRb = GetComponent<Rigidbody>();
            _juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
        }


        private void Slice(Vector3 direction, Vector3 position, float force) {
            FindObjectOfType<FruitNinjaGameManager>().IncreaseScore(points);
            whole.SetActive(false);
            sliced.SetActive(true);
            _fruitCollider.enabled = false;
            _juiceParticleEffect.Play();
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            var slices = sliced.GetComponentsInChildren<Rigidbody>();
            foreach (var slice in slices) {
                slice.velocity = _fruitRb.velocity;
                slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                var blade = other.GetComponent<Blade>();
                Slice(blade.Direction, blade.transform.position, blade.sliceForce);
            }
        }
    }
}
