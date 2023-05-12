using UnityEngine;

namespace Tetris.Scripts
{
    public class Piece : MonoBehaviour
    {
        public Board Board { get; private set; }
        public TetrominoData Data { get; private set; }
        
        public Vector3Int[] Cells { get; private set; }
        public Vector3Int Position { get; private set; }
        
        public int RotationIndex { get; private set; }


        private void Update() {
            
            Board.Clear(this);

            if (Input.GetKeyDown(KeyCode.Q)) {
                Rotate(-1);
            }else if (Input.GetKeyDown(KeyCode.E)) {
                Rotate(1);
            }
            
            if (Input.GetKeyDown(KeyCode.A)) {
                Move(Vector2Int.left);
                
            }else if (Input.GetKeyDown(KeyCode.D)) {
                Move(Vector2Int.right);
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                Move(Vector2Int.down);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                HardDrop();
            }
            
            Board.Set(this);
        }

        private void HardDrop()
        {
            while (Move(Vector2Int.down)) {
                continue;
            }
        }

        private bool Move(Vector2Int translation)
        {
            Vector3Int newPos = this.Position;
            newPos.x += translation.x;
            newPos.y += translation.y;

            var valid = Board.IsValidPosition(this, newPos);
            if (valid) {
                Position = newPos;
            }
            return valid;
        }


        public void Initialize(Board board, Vector3Int position, TetrominoData data)
        {
            Board = board;
            Position = position;
            Data = data;
            RotationIndex = 0;

            if (Cells == null) {
                Cells = new Vector3Int[data.Cells.Length];
            }

            for (int i = 0; i < data.Cells.Length; i++) {
                Cells[i] = (Vector3Int)data.Cells[i];
            }
        }

        private void Rotate(int direction) {
            RotationIndex = Wrap(this.RotationIndex + direction, 0, 4);
            for (int i = 0; i < Cells.Length; i++)
            {
                Vector3 cell = Cells[i];
                int x;
                int y;
                switch (Data.Tetromino)
                {
                    case Tetromino.I:
                    case Tetromino.O:
                        cell.x -= 0.5f;
                        cell.y -= 0.5f;
                        x = Mathf.CeilToInt( (cell.x * Scripts.Data.RotationMatrix[0] * direction) + (cell.y * Scripts.Data.RotationMatrix[1] * direction));
                        y = Mathf.CeilToInt((cell.x * Scripts.Data.RotationMatrix[2] * direction) + (cell.y * Scripts.Data.RotationMatrix[3] * direction));
                        break;
                    default:
                        x = Mathf.RoundToInt( (cell.x * Scripts.Data.RotationMatrix[0] * direction) + (cell.y * Scripts.Data.RotationMatrix[1] * direction));
                        y = Mathf.RoundToInt((cell.x * Scripts.Data.RotationMatrix[2] * direction) + (cell.y * Scripts.Data.RotationMatrix[3] * direction));
                        break;
                }

                Cells[i] = new Vector3Int(x, y, 0);


            }
        }

        private int Wrap(int input, int min, int max) {
            
            if (input < min) {
                return max - (min - input) % (max - min);
            }
            else {
                return min + (input - min) % (max - min);
            }
        }
    }
}
