using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace FlappyBird.Scripts
{
    public class Pipes : MonoBehaviour
    {
        public float speed = 5f;
        private float leftEdge;

        private void Start()
        {
            leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 12;
        }


        private void Update()
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);

            if (transform.position.x < leftEdge)
            {
                Destroy(gameObject);
            }
        }
    }
}
