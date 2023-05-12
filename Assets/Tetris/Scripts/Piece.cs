using UnityEngine;

namespace Tetris.Scripts
{
    public class Piece : MonoBehaviour
    {
        public Board Board { get; private set; }
        public TetrominoData Data { get; private set; }
        
        public Vector3Int[] Cells { get; private set; }
        public Vector3Int Position { get; private set; }
        
        public void Initialize(Board board, Vector3Int position, TetrominoData data)
        {
            Board = board;
            Position = position;
            Data = data;

            if (Cells == null) {
                Cells = new Vector3Int[data.Cells.Length];
            }

            for (int i = 0; i < data.Cells.Length; i++) {
                Cells[i] = (Vector3Int)data.Cells[i];
            }
        }
    }
}
