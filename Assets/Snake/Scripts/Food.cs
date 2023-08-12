using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Snake.Scripts {
    public class Food : MonoBehaviour {

        public BoxCollider2D area;
        [SerializeField] private Snake snake;
        private List<Vector3> possibleFoodPositions = new();
        

        private void Start() {
            var bounds = area.bounds;
            for (int i = (int)bounds.min.x; i < bounds.max.x; i++) {
                for (int j = (int)bounds.min.y; j < bounds.max.y; j++) {
                    possibleFoodPositions.Add(new Vector3(i,j,0));
                }
            }
            RandomPosition();
        }
        
        public void RemoveFromPossibleFoodPositions(Vector3 position) {
            possibleFoodPositions.Remove(position);
        }
        
        public void AddFromPossibleFoodPositions(Vector3 position) {
            possibleFoodPositions.Add(position);
        }

        private void RandomPosition() {
            var rnd = Random.Range(0, possibleFoodPositions.Count);
            transform.position = possibleFoodPositions[rnd];

        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                RandomPosition();
            }
        }
    }
}