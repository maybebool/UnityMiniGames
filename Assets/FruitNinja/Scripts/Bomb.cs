using UnityEngine;

namespace FruitNinja.Scripts {
    public class Bomb : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                FindObjectOfType<FruitNinjaGameManager>().Explode();
            }
        }
    }
}
