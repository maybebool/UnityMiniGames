using UnityEngine;

namespace Breakout.Scripts {
    public class BreakoutPaddle : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float borderLength;


    
        private void Update() {
            Movement();
        }

        private void Movement() {

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -borderLength) {
                transform.position += Vector3.left * (speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < borderLength) {
                transform.position += Vector3.right * (speed * Time.deltaTime);
            }

        }
    }
}
