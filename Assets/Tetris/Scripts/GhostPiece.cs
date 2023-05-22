using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Scripts
{
    public class GhostPiece : MonoBehaviour
    {
        public Tile tile;
        public Board board;
        public Piece trackingPiece;
        
        public Tilemap tileMap { get; private set; }
        public Vector3Int[] cells { get; private set; }
        public Vector3Int position { get; private set; }

        private void Awake()
        {
            tileMap = GetComponentInChildren<Tilemap>();
            cells = new Vector3Int[4];
        }

        private void LateUpdate()
        {
            Clear();
            Copy();
            Drop();
            
        }


        private void Clear()
        {
            for (int i = 0; i < cells.Length; i++) {
                var tilePos = cells[i] + position;
                tileMap.SetTile(tilePos, null);
            }
        }

        private void Drop()
        {
            
        }

        private void Copy() {
            for (int i = 0; i < cells.Length; i++) {
                cells[i] = trackingPiece.Cells[i];
            }
        }

        private void Set() {
            for (int i = 0; i < cells.Length; i++) {
                var tilePos = cells[i] + position;
                tileMap.SetTile(tilePos, tile);
            }
        }
        
        
        
    }
}
