using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class RegularEnemy : MonoBehaviour {
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite[] animationSprites;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float animationTime = 0.6f;
        private int _enemyFrame;

        private void Start() {
            InvokeRepeating(nameof(EnemyAnimation), animationTime, animationTime);
        }

        private void EnemyAnimation() {
            _enemyFrame++;
            if (_enemyFrame >= animationSprites.Length) {
                _enemyFrame = 0;
            }

            spriteRenderer.sprite = animationSprites[_enemyFrame];
        }

        public void ShootBullet() {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}