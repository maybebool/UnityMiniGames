using UnityEngine;
using UnityEngine.Tilemaps;


namespace Tetris.Scripts {
    public enum Tetromino {
        I,
        O,
        T,
        J,
        L,
        S,
        Z
    }

    [System.Serializable]
    public struct TetrominoData {
        public Tetromino Tetromino;
        public Tile Tile;
        public Vector2Int[] Cells { get; private set; }
        public Vector2Int[,] wallKicks { get; private set; }

        public void Initialize() {
            Cells = Data.Cells[Tetromino];
            wallKicks = Data.TetrominoWallContact[Tetromino];
        }
    }
}