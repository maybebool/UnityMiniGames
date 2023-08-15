using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceGame.Scripts {
    public class Parallax : MonoBehaviour {
        [SerializeField] private MeshRenderer mr;
        [SerializeField] private float animtaionSpeed;


        private void Update() {
            mr.material.mainTextureOffset += new Vector2(animtaionSpeed * Time.deltaTime, 0f);
        }
    }
}
