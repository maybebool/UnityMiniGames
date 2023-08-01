using UnityEngine;

namespace BubbleShooter.Scripts {
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform projTransform;
        
        private void Update() {
            projTransform.position += transform.up * (Time.deltaTime * speed);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Boundries")) {
                Destroy(gameObject);
                Cannon.Instance.SetCanShoot(true);
            }

            if (other.CompareTag("Bubble")) {
                Destroy(other.gameObject);
                BSGameManager.Instance.IncreaseBubblePoints();
            }
        }
    }
}
