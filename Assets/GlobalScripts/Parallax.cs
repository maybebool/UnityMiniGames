using System;
using UnityEngine;

namespace GlobalScripts {
    [Flags]
    public enum GameName {
        Nothing = 0,
        FlappyBird = 1,
        DoodleJump = 2
    }

    public class Parallax : MonoBehaviour {
        public GameName gameName;
        private MeshRenderer _meshRenderer;
        public float animationSpeed = 0.05f;


        private void Awake() {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update() {
            if (gameName == GameName.Nothing) {
                return;
            }

            if (gameName == GameName.FlappyBird) {
                _meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
            }

            if (gameName == GameName.DoodleJump) {
                _meshRenderer.material.mainTextureOffset += new Vector2(0, animationSpeed * Time.deltaTime);
            }
        }
    }
}