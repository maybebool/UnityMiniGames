using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Tetris.Scripts {
    public class Board : MonoBehaviour {
        
        public Vector2Int boardSize = new(10, 20);
        private Tilemap TileMap { get; set; }
        private Piece Piece { get; set; }
        [SerializeField] private TetrominoData[] tetrominos;
        [SerializeField] private Vector3Int spawnPos;

        private RectInt Bounds {
            get {
                var pos = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
                return new RectInt(pos, boardSize);
            }
        }

        private void Awake() {
            TileMap = GetComponentInChildren<Tilemap>();
            Piece = GetComponentInChildren<Piece>();
            for (int i = 0; i < tetrominos.Length; i++) {
                tetrominos[i].Initialize();
            }
        }

        private void Start() {
            SpawnPiece();
        }

        public void SpawnPiece() {
            var random = Random.Range(0, tetrominos.Length);
            var data = tetrominos[random];
            Piece.Initialize(this, spawnPos, data);
            if (IsValidPosition(Piece, spawnPos)) {
                Set(Piece);
            }
            else {
                GameOver();
            }
            Set(Piece);
        }

        private void GameOver() {
            TileMap.ClearAllTiles();
        }


        public void Set(Piece piece) {
            foreach (var t in piece.Cells) {
                var tilePos = t + piece.Position;
                TileMap.SetTile(tilePos, piece.Data.Tile);
            }
        }

        public void Clear(Piece piece) {
            foreach (var t in piece.Cells) {
                var tilePos = t + piece.Position;
                TileMap.SetTile(tilePos, null);
            }
        }

        public bool IsValidPosition(Piece piece, Vector3Int position) {
            var bounds = Bounds;

            foreach (var t in piece.Cells) {
                var tilePos = t + position;
                if (!bounds.Contains((Vector2Int)tilePos)) {
                    return false;
                }

                if (TileMap.HasTile(tilePos)) {
                    return false;
                }
            }
            return true;
        }

        public void ClearLine() {
            var bounds = Bounds;
            var row = bounds.yMin;
            while (row < bounds.yMax) {
                if (IsLineFull(row)) {
                    LineClear(row);
                }
                else {
                    row++;
                }
            }
        }

        private bool IsLineFull(int row) {
            var bounds = Bounds;
            for (int col = bounds.xMin; col < bounds.xMax; col++) {
                var pos = new Vector3Int(col, row, 0);
                if (!TileMap.HasTile(pos)) {
                    return false;
                }
            }
            return true;
        }

        private void LineClear(int row) {
            var bounds = Bounds;
            for (int col = bounds.xMin; col < bounds.xMax; col++) {
                var pos = new Vector3Int(col, row, 0);
                TileMap.SetTile(pos, null);
            }

            while (row < bounds.xMax) {
                for (int col = bounds.xMin; col < bounds.xMax; col++) {
                    var pos = new Vector3Int(col, row + 1, 0);
                    var above = TileMap.GetTile(pos);
                    pos = new Vector3Int(col, row, 0);
                    TileMap.SetTile(pos, above);
                }
                row++;
            }
        }
    }
}