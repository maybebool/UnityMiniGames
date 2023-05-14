using System;
using UnityEngine;

namespace Pong.Scripts
{
    public class Paddle : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;


        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}
