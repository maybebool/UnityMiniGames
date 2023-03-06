using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


[System.Flags]
public enum PlatformType {
    Nothing = 0, 
    NormalBounce = 1,
    SpringBounce = 2,
    JetPackBounce = 4
}

namespace DoodleJump.Scripts
{
    public class PlatformBounce : MonoBehaviour {

        public PlatformType bounce;
        
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
                if (bounce == PlatformType.Nothing) {
                    return;
                }

                if (bounce == PlatformType.NormalBounce) {
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);
                }

                if (bounce == PlatformType.SpringBounce) {
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1200f);
                }
            }
        }
    }
}
