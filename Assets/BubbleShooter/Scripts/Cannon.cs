using UnityEngine;

namespace BubbleShooter.Scripts {
    public class Cannon : MonoBehaviour {
    
        public static Cannon Instance;
        [SerializeField] private Camera cam;
        [SerializeField] private Transform player;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletPivot;
        
        private int _ammoCount = 5;
        private bool _canShoot = true;

        
        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }

        private void Start() {
            BSGameManager.Instance.AmmoCountDisplay(_ammoCount);
        }

        private void Update() {
            if (Input.mousePosition.y >= cam.WorldToScreenPoint(transform.position).y) {
                FollowMousePosition();
            }

            if (!Input.GetMouseButtonUp(0)) return;
            if (!_canShoot) return;
            if (_ammoCount < 1) return;
            
            Instantiate(bullet, bulletPivot.position, player.rotation);
            _ammoCount--;
            BSGameManager.Instance.AmmoCountDisplay(_ammoCount);
            _canShoot = false;
        }


        private void FollowMousePosition() {
            var orbVector = cam.WorldToScreenPoint(player.transform.position);
            orbVector = Input.mousePosition - orbVector;
            var angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;
            player.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        public void SetCanShoot(bool canShoot) {
            _canShoot = canShoot;
            if (_ammoCount < 1) {
                BSGameManager.Instance.GameOver();
            }
        }
    }
}
