using UnityEngine;

namespace DoodleJump.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D rb2d;

        private float moveInput;

        private float speed = 10;
        
        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        }
    }
}
