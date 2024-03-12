using UnityEngine;

namespace Pong.Scripts {
    public class Paddle : MonoBehaviour {
        protected Rigidbody2D rb2d;
        protected readonly float speed = 10;
        
        private void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void ResetPosition() {
            rb2d.position = new Vector2(rb2d.position.x, 0f);
            rb2d.velocity = Vector2.zero;
        }
    }
}