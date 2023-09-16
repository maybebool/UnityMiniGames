using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace FlappyBird.Scripts {
    public class Player : MonoBehaviour {
        private Vector3 _direction;
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float strength = 5f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite[] sprites;
        private int spriteIndex;
        [SerializeField] private GameObject manager;


        private void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start() {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                _direction = Vector3.up * strength;
            }

            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    _direction = Vector3.up * strength;
                }
            }

            _direction.y += gravity * Time.deltaTime;
            transform.position += _direction * Time.deltaTime;
        }

        private void AnimateSprite() {
            spriteIndex++;
            if (spriteIndex >= sprites.Length) {
                spriteIndex = 0;
            }

            spriteRenderer.sprite = sprites[spriteIndex];
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Obsticle")) {
                manager.GetComponent<GameManager>().GameOver();
            }
            else if (col.gameObject.CompareTag("Scoring")) {
                manager.GetComponent<GameManager>().IncreaseScore();
            }
        }
    }
}