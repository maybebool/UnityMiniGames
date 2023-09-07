using System;
using UnityEngine;

namespace Pong.Scripts {
    public class BounceSurface : MonoBehaviour {
        public float bounceStrength;

        // increase speed by contact
        private void OnCollisionEnter2D(Collision2D other) {
            var ball = other.gameObject.GetComponent<Ball>();
            if (ball == null) return;
            var normal = other.GetContact(0).normal;
            ball.AddForce(-normal * bounceStrength);
        }
    }
}