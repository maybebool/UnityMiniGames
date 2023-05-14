
using System;
using UnityEngine;

namespace Pong.Scripts
{
    public class AiPaddle : Paddle
    {
        public Rigidbody2D ball;
        
        private void FixedUpdate()
        {
            if (ball.velocity.x > 0){

                if (ball.position.y > transform.position.y)
                {
                    Rigidbody.AddForce(Vector2.up * speed);
                }else if (ball.position.y < transform.position.y) {
                    Rigidbody.AddForce(Vector2.down * speed);
                }
            }
            else
            {
                
            }
            
        }
    }
}
