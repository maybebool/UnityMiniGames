using UnityEngine;

namespace DoodleJump.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D rb2d;
        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
