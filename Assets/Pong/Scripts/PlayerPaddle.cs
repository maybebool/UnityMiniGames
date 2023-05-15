using System;
using UnityEngine;

namespace Pong.Scripts
{
    public class PlayerPaddle : Paddle
    {
        private Vector2 _direction;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                _direction = Vector2.up;
                
            }else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                _direction = Vector2.down;
            }
            else {
                _direction = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            if (_direction.sqrMagnitude != 0) {
                Rigidbody.AddForce(_direction * speed);
            }
        }
    }
}
