using UnityEngine;

namespace SpaceWars.Scripts {
    public class GunUpgrade : MonoBehaviour {
        [SerializeField] private float speed;

        private void Update() {
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
        }
    }
}
