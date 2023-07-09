using System;
using UnityEditor;
using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class Invaders : MonoBehaviour
    {
        
        public int rows, columns;
        public GameObject[] prefabs;
        public float offset = 2.0f;

        private void Awake() {
            
        }

        private void Start() {
            for (int row = 0; row < rows; row++) {
                
                var width = offset * (columns - 1);
                var height = offset * (rows - 1);
                var centering = new Vector2(-width / 2, -height / 2);
                var rowPos = new Vector3(centering.x,  centering.y + row * offset, 0.0f);
                
                for (int col = 0; col < columns; col++) {
                    var invader = Instantiate(prefabs[row], transform);
                    var position = rowPos;
                    position.x += col * offset;
                    invader.transform.localPosition = position;
                }
            }
        }
    }
}
