using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class Bullet : MonoBehaviour {
        
        [SerializeField] private float speed;
        private Vector3 _directionUp = Vector3.up;
        private Vector3 _directionDown = Vector3.down;

        public bool IsPlayer { get;  set; }

        private void Update() {
            if (IsPlayer) {
                
                transform.position += _directionUp * (speed * Time.deltaTime);
            }
            else {
                transform.position += _directionDown * (speed * Time.deltaTime);
            }
        }


        private void OnTriggerEnter2D(Collider2D other) {

            if (IsPlayer) {
                if (other.CompareTag("Enemy")) {
                    Destroy(other.gameObject);
                    SIGameManager.Instance.PointCounter(1);
                    EnemyGrid.Instance.CorrectingCurrentArmyCount(other.gameObject.GetComponent<RegularEnemy>());
                    Destroy(gameObject);
                }
                
                if (other.CompareTag("SpecialUFO")) {
                    SIGameManager.Instance.PointCounter(10);
                    Destroy(gameObject);
                }
            }
            else {
                if (other.CompareTag("Player")) {
                    SIGameManager.Instance.PlayerLifeSetter();
                    Destroy(gameObject);
                }
            }

            if (other.CompareTag("Boundries")) {
                Destroy(gameObject);
            }
        }


        private void OnDestroy() {
            if (IsPlayer) {
                Player.Instance.bulletOnTheField = false;
            }
        }
    }
}
