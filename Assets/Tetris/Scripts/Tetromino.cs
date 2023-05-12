using UnityEngine;
using UnityEngine.Tilemaps;


namespace Tetris.Scripts
{
    public enum Tetromino
    {
        I,
        O,
        T,
        J,
        L,
        S,
        Z
    }

    public struct TetrominoData
    {
        public Tetromino Tetromino;
        public Tile Tile;
    }
}
