using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Scripts {
    public class GhostPiece : MonoBehaviour {
        public Tile tile;
        public Board mainBoard;
        public Piece trackingPiece;
        public Tilemap tilemap { get; private set; }
        public Vector3Int[] cells { get; private set; }
        public Vector3Int position { get; private set; }

        private void Awake() {
            tilemap = GetComponentInChildren<Tilemap>();
            cells = new Vector3Int[4];
        }

        private void LateUpdate() {
            Clear();
            Copy();
            Drop();
            Set();
        }

        private void Clear() {
            for (int i = 0; i < cells.Length; i++) {
                var tilePosition = cells[i] + position;
                tilemap.SetTile(tilePosition, null);
            }
        }

        private void Copy() {
            for (int i = 0; i < cells.Length; i++) {
                cells[i] = trackingPiece.Cells[i];
            }
        }

        private void Drop() {
            var position = trackingPiece.Position;

            int current = position.y;
            int bottom = -mainBoard.boardSize.y / 2 - 1;

            mainBoard.Clear(trackingPiece);

            for (int row = current; row >= bottom; row--) {
                position.y = row;

                if (mainBoard.IsValidPosition(trackingPiece, position)) {
                    this.position = position;
                }
                else {
                    break;
                }
            }
            mainBoard.Set(trackingPiece);
        }

        private void Set() {
            for (int i = 0; i < cells.Length; i++) {
                var tilePosition = cells[i] + position;
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }
}