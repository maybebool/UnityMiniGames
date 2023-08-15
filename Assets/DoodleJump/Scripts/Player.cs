using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] private Camera camera;
    [SerializeField] private float normalspeed;
    [SerializeField] private float springspeed;
    [SerializeField] private float speed;
    [SerializeField] private Text scoreText;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private List<Transform> platforms = new();

    private float score;
    private float _moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void Update() {
        FlipSpriteBasedOnDirection();
        InfiniteScreenLeftRight();
        _moveInput = Input.GetAxis("Horizontal");

        if (transform.position.y >= 0 ) {
            score += 0.1f;
        
            transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);
            for (int i = 0; i < platforms.Count; i++) {
                platforms[i].position += Vector3.down * (scrollSpeed * Time.deltaTime);
            }
        }

        scoreText.text = "Score: " + Mathf.Round(score);
    }


    private void FixedUpdate() {
        rb.velocity = new Vector2(_moveInput * speed, rb.velocity.y);
    }

    private void FlipSpriteBasedOnDirection() {
        if (_moveInput < 0) {
            sr.flipX = true;
        }else if (_moveInput > 0) {
            sr.flipX = false;
        }
    }

    private void InfiniteScreenLeftRight() {
        if (transform.position.x >= 5.6f) {
            transform.position = new Vector3(-5.58f, transform.position.y, 0f);
        }else if (transform.position.x <= -5.6f) {
            transform.position = new Vector3(5.58f, transform.position.y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (rb.velocity.y <= 0) {
            if (other.CompareTag("NormalPlatform")) {
                rb.velocity = Vector2.zero;
                rb.velocity += (Vector2.up * normalspeed);
            }
            if (other.CompareTag("SpringPlatform")) {
                rb.velocity = Vector2.zero;
                rb.velocity += (Vector2.up * springspeed);
            }
        }
    }
}
    
    
    
