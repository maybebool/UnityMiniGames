using System;
using UnityEngine;

namespace Pong.Scripts
{
    public class Paddle : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;
        protected float speed = 10;


        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        public void ResetPosition()
        {
            Rigidbody.position = new Vector2(Rigidbody.position.x, 0f);
            Rigidbody.velocity = Vector2.zero;
        }
    }
}
