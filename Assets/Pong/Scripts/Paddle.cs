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
    }
}
