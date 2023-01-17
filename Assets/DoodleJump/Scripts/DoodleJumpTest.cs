using UnityEngine;

namespace DoodleJump.Scripts
{
    public class DoodleJumpTest : MonoBehaviour
    {

        private Vector3 leftEdge;

        private float speed;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void Jumper()
        {
            
        }

        private void VectorLeft()
        {
            leftEdge = Vector3.left * speed * Time.deltaTime;

        }



    }
}
