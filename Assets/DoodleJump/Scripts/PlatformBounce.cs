using System;
using UnityEngine;

namespace DoodleJump.Scripts
{
    public class PlatformBounce : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);
            }
        }
    }
}
