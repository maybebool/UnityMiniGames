using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceWars.Scripts {
    public class Parallax : MonoBehaviour {
        [SerializeField] private MeshRenderer mr;
        [SerializeField] private float animationSpeed;


        private void Update() {
            mr.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0f);
        }
    }
}
