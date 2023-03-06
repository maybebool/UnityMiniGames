using System;
using GlobalScripts;
using UnityEngine;
using UnityEngine.Animations;

namespace DoodleJump.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D _rb2d;
        private float _moveInput;
        private float _speed = 10;
        private float _localX;
        public GameName flag;

        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _localX = transform.localScale.x;
        }

        private void Update() {
            _moveInput = Input.GetAxis("Horizontal");
        }

        // Update is called once per frame
        private void FixedUpdate() {
            Flip();
            _rb2d.velocity = new Vector2(_moveInput * _speed, _rb2d.velocity.y);
        }


        private void Flip() {
            if (_moveInput > 0) {
                gameObject.transform.localScale = new Vector3(_localX, transform.localScale.y, transform.localScale.z);
            }

            if (_moveInput < 0) {
                gameObject.transform.localScale =
                    new Vector3((-1) * _localX, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
