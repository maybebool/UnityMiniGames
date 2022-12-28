using System;
using UnityEngine;

namespace FlappyBird.Scripts
{
    public class Parallax : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        public float animationSpeed = 0.05f;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            
        }

        private void Update()
        {
            _meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
        }
    }
}
