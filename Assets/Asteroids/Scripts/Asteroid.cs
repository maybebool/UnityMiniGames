using UnityEngine;

namespace Asteroids.Scripts {
    public class Asteroid : MonoBehaviour {
        
        [SerializeField] private Rigidbody2D rbAsteroid;
        [SerializeField] private SpriteRenderer srAsteroid;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float smallAsteroidMaxsize = 1.4f;
        [SerializeField] private float minSize = 0.4f;
        [SerializeField] private float maxSize = 2f;
        [SerializeField] private float speed = 20f;
        [SerializeField] private float camFieldXMax, camFieldYMax;
        private bool _spawnProtection = true;


        public void AsteroidSetup(bool isInitialSize) {
            srAsteroid.sprite = sprites[Random.Range(0, sprites.Length)];
            var ankerPoint = new Vector2(Random.Range(-camFieldXMax, camFieldXMax),
                Random.Range(-camFieldYMax, camFieldYMax));

            var direction = ankerPoint - (Vector2)transform.position;
            rbAsteroid.velocity = direction * speed;

            var scale = 0f;

            scale = Random.Range(minSize, isInitialSize ? maxSize : smallAsteroidMaxsize);

            transform.localScale = new Vector2(scale, scale);
        }

        
        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.gameObject.CompareTag("Bullet")) return;
            if (transform.localScale.x > smallAsteroidMaxsize) {
                var rnd = Random.Range(2, 5);
                for (int i = 0; i < rnd; i++) {
                    var smallAsteroid = Instantiate(gameObject, transform.position, transform.rotation)
                        .GetComponent<Asteroid>();
                    smallAsteroid.AsteroidSetup(false);
                }
            }

            AsteroidsGameManager.Instance.PointCounter();
            Destroy(gameObject);
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Boundries")) {
                if (_spawnProtection) {
                    _spawnProtection = false;
                }
                else {
                    Destroy(gameObject);
                }
            }
        }
    }
}