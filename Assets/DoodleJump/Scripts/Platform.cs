using UnityEngine;
using Random = UnityEngine.Random;

namespace DoodleJump.Scripts {
    public class Platform : MonoBehaviour {
        
        [SerializeField] private Player player;
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("PlatformSetter")) {
                transform.position = new Vector2(Random.Range(-5.5f, 5.5f),
                    player.transform.position.y + (2 + Random.Range(3f, 6f)));
            }
        }
    }
}
