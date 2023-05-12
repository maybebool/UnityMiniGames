using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Tetris.Scripts
{
    public class Board : MonoBehaviour
    {
        public Tilemap Tilemap { get; private set; }
        public Piece Piece { get; private set; }
        public TetrominoData[] tetrominos;
        public Vector3Int spawnPos;

        private void Awake() {
            
            Tilemap = GetComponentInChildren<Tilemap>();
            Piece = GetComponentInChildren<Piece>();
            for (int i = 0; i < tetrominos.Length; i++) {
                tetrominos[i].Initialize();
            }
        }

        private void Start()
        {
            SpawnPiece();
        }

        public void SpawnPiece() {
            var random = Random.Range(0, this.tetrominos.Length);
            var data = this.tetrominos[random];
            this.Piece.Initialize(this, spawnPos, data);
            Set(this.Piece);
        }


        public void Set(Piece piece) {
            for (int i = 0; i < piece.Cells.Length; i++) {
                
                var tilePos = piece.Cells[i] + piece.Position;
                this.Tilemap.SetTile(tilePos, piece.Data.Tile);
            }
        }
    }
}
