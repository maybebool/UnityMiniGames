using UnityEngine;

namespace Pong.Scripts {
    public class AiPaddle : Paddle {
        public Rigidbody2D ball;
        public float threshold = 2;

        private void FixedUpdate() {
            if (ball.velocity.x > 0 + threshold) {
                if (ball.position.y > transform.position.y) {
                    rb2d.AddForce(Vector2.up * speed);
                }
                else if (ball.position.y < transform.position.y) {
                    rb2d.AddForce(Vector2.down * speed);
                }
            }
            else {
                if (transform.position.y > 0.0f) {
                    rb2d.AddForce(Vector2.down * speed);
                }
                else if (transform.position.y < 0.0f) {
                    rb2d.AddForce(Vector2.up * speed);
                }
            }
        }
    }
}