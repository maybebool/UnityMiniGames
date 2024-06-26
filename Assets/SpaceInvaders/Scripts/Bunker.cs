using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class Bunker : MonoBehaviour {
        
        [SerializeField] private int lifePoints;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Enemy")) {
                SpaceInvadersManager.Instance.UIPanelScreen();
            }

            if (!other.CompareTag("Bullet")) return;
            if (lifePoints > 0) {
                lifePoints--;
            }
            else {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}