using System;
using TMPro;
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
        public TextMeshProUGUI scoreText;
        private float _topScore = 0f;

        // Start is called before the first frame update
        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _localX = transform.localScale.x;
        }

        private void Update() {
            Flip();
            _moveInput = Input.GetAxis("Horizontal");

            if (_rb2d.velocity.y > 0 && transform.position.y > _topScore) {
                _topScore = transform.position.y;
            }
            scoreText.text = "Score: " + Mathf.Round(_topScore);
        }

        // Update is called once per frame
        private void FixedUpdate() {
            
            _rb2d.velocity = new Vector2(_moveInput * _speed, _rb2d.velocity.y);
        }


        private void Flip() {
            if (_moveInput < 0) {
                this.GetComponent<SpriteRenderer>().flipX = true;
                
            }

            if (_moveInput > 0) {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
