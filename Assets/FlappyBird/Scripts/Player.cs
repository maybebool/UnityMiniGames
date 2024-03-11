using UnityEngine;

namespace FlappyBird.Scripts {
    public class Player : MonoBehaviour {
        
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float strength = 5f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private GameObject manager;
        private int _spriteIndex;
        private Vector3 _direction;


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
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    _direction = Vector3.up * strength;
                }
            }

            _direction.y += gravity * Time.deltaTime;
            transform.position += _direction * Time.deltaTime;
        }

        private void AnimateSprite() {
            _spriteIndex++;
            if (_spriteIndex >= sprites.Length) {
                _spriteIndex = 0;
            }

            spriteRenderer.sprite = sprites[_spriteIndex];
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Obsticle")) {
                manager.GetComponent<FlappyBirdManager>().GameOver();
            }
            else if (col.gameObject.CompareTag("Scoring")) {
                manager.GetComponent<FlappyBirdManager>().IncreaseScore();
            }
        }
    }
}