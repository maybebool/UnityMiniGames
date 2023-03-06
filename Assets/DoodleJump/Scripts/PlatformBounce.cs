using System;
using UnityEngine;

namespace DoodleJump.Scripts
{
    public class PlatformBounce : MonoBehaviour
    {
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);
            }
        }
    }
}
