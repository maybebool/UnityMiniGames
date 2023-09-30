using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class RegularEnemy : MonoBehaviour {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite[] animationSprites;
        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] private float animationTime = 0.6f;
        private int enemyFrame;

        private void Start() {
            InvokeRepeating(nameof(EnemyAnimation), animationTime, animationTime);
        }

        private void EnemyAnimation() {
            enemyFrame++;
            if (enemyFrame >= animationSprites.Length) {
                enemyFrame = 0;
            }

            spriteRenderer.sprite = animationSprites[enemyFrame];
        }

        public void ShootBullet() {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}