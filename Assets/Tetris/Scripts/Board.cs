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
        public Vector2Int boardSize = new Vector2Int(10, 20);

        public RectInt Bounds
        {
            get
            {
                Vector2Int pos = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
                return new RectInt(pos, boardSize);
            }
        }

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
            if (IsValidPosition(Piece,spawnPos))
            {
                Set(Piece);
            }
            else
            {
                GameOver();
            }
            Set(Piece);
        }

        private void GameOver()
        {
            Tilemap.ClearAllTiles();
        }


        public void Set(Piece piece) {
            for (int i = 0; i < piece.Cells.Length; i++) {
                
                var tilePos = piece.Cells[i] + piece.Position;
                this.Tilemap.SetTile(tilePos, piece.Data.Tile);
            }
        }
        
        public void Clear(Piece piece) {
            for (int i = 0; i < piece.Cells.Length; i++) {
                
                var tilePos = piece.Cells[i] + piece.Position;
                Tilemap.SetTile(tilePos, null);
            }
        }
        
        public bool IsValidPosition(Piece piece, Vector3Int position) {
            
            var bounds = this.Bounds;
            
            for (int i = 0; i < piece.Cells.Length; i++) {
                var tilePos = piece.Cells[i] + position;
                if (!bounds.Contains((Vector2Int)tilePos)) {
                    return false;
                }
                if (Tilemap.HasTile(tilePos)) {
                    return false;
                }
            }
            return true;
        }

        public void ClearLine()
        {
            var bounds = this.Bounds;
            var row = bounds.yMin;
            while (row < bounds.yMax)
            {
                if (IsLineFull(row))
                {
                    LineClear(row);
                }
                else
                {
                    row++;
                }
            }
        }

        private bool IsLineFull(int row)
        {
            var bounds = Bounds;
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                var pos = new Vector3Int(col, row, 0);
                if (!Tilemap.HasTile(pos))
                {
                    return false;
                }
            }

            return true;
        }

        private void LineClear(int row) {
            var bounds = Bounds;
            for (int col = bounds.xMin; col < bounds.xMax; col++) {
                var pos = new Vector3Int(col, row, 0);
                Tilemap.SetTile(pos,null);
            }

            while (row < bounds.xMax) {
                for (int col = bounds.xMin; col < bounds.xMax; col++) {
                    var pos = new Vector3Int(col, row + 1, 0);
                    var above = Tilemap.GetTile(pos);
                    pos = new Vector3Int(col, row, 0);
                    Tilemap.SetTile(pos,above);
                }

                row++;
            }
        }
    }
}
