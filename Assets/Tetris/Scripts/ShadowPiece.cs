using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Scripts {
    public class ShadowPiece : MonoBehaviour {
        [SerializeField] private Tile tile;
        [SerializeField] private Board mainBoard;
        [SerializeField] private Piece trackingPiece;
        private Tilemap tileMap { get; set; }
        private Vector3Int[] cells { get; set; }
        private Vector3Int position { get; set; }

        private void Awake() {
            tileMap = GetComponentInChildren<Tilemap>();
            cells = new Vector3Int[4];
        }

        private void LateUpdate() {
            Clear();
            Copy();
            Drop();
            Set();
        }

        private void Clear() {
            foreach (var t in cells) {
                var tilePosition = t + position;
                tileMap.SetTile(tilePosition, null);
            }
        }

        private void Copy() {
            for (int i = 0; i < cells.Length; i++) {
                cells[i] = trackingPiece.Cells[i];
            }
        }
        
        private void Drop() {
            var position = trackingPiece.Position;
            var current = position.y;
            var bottom = CalculateBottom();

            ClearPiece();

            for (int row = current; row >= bottom; row--) {
                position.y = row;
                if (IsPositionValid(position)) {
                    this.position = position;
                }
                else {
                    break;
                }
            }

            SetPiece();
        }

        private int CalculateBottom() {
            return -mainBoard.boardSize.y / 2 - 1;
        }

        private void ClearPiece() {
            mainBoard.Clear(trackingPiece);
        }

        private void SetPiece() {
            mainBoard.Set(trackingPiece);
        }

        private bool IsPositionValid(Vector3Int position) {
            return mainBoard.IsValidPosition(trackingPiece, position);
        }

        private void Set() {
            foreach (var t in cells) {
                var tilePosition = t + position;
                tileMap.SetTile(tilePosition, tile);
            }
        }
    }
}