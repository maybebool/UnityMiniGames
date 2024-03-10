using System.Collections.Generic;
using UnityEngine;

namespace BubbleShooter.Scripts {
    public class BubbleSpawner : MonoBehaviour {
        
        [SerializeField] private GameObject bubblePrefab;
        [SerializeField] private float offsetX = 1;
        [SerializeField] private float offsetY = 0.5f;
        [SerializeField] private Vector3 spawnPos;
        [SerializeField] private List<Color> colors;
        
        
        private int _columns = 7;
        private int _rows = 4;
        
        
        private void Start() {
            for (int i = 0; i < _rows; i++) {
                CreateBubbleRow(i);
                AdjustSpawnPosAndColumns();
            }
        }

        private void CreateBubbleRow(int rowIndex) {
            var currentXPos = spawnPos.x;
            for (int j = 0; j < _columns; j++) {
                var bubble = Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
                BubbleList.bubbleList.Add(bubble);
                bubble.GetComponent<MeshRenderer>().material.color = colors[rowIndex];
                spawnPos.x += offsetX;
            }
            spawnPos.x = currentXPos + offsetX;
        }

        private void AdjustSpawnPosAndColumns() {
            spawnPos.y -= offsetY;
            _columns -= 2;
        }
    }
}
