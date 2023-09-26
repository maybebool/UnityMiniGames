using UnityEngine;
namespace Tetris.Scripts {
    public class Piece : MonoBehaviour {
        public Board Board { get; private set; }
        public TetrominoData Data { get; private set; }

        public Vector3Int[] Cells { get; private set; }
        public Vector3Int Position { get; private set; }

        public int RotationIndex { get; private set; }

        public float stepDelay = 1f;
        public float lockDelay = .5f;
        private float _stepTime;
        private float _lockTime;


        private void Update() {
            Board.Clear(this);

            _lockTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Q)) {
                Rotate(-1);
            }
            else if (Input.GetKeyDown(KeyCode.E)) {
                Rotate(1);
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                Move(Vector2Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                Move(Vector2Int.right);
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                Move(Vector2Int.down);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                HardDrop();
            }

            if (Time.time >= _stepTime) {
                Step();
            }

            Board.Set(this);
        }

        private void Step() {
            _stepTime = Time.time + stepDelay;
            Move(Vector2Int.down);
            if (_lockTime >= lockDelay) {
                Lock();
            }
        }

        private void Lock() {
            Board.Set(this);
            Board.ClearLine();
            Board.SpawnPiece();
        }


        private void HardDrop() {
            while (Move(Vector2Int.down)) {
                continue;
            }
            Lock();
        }

        private bool Move(Vector2Int translation) {
            Vector3Int newPos = this.Position;
            newPos.x += translation.x;
            newPos.y += translation.y;

            var valid = Board.IsValidPosition(this, newPos);
            if (valid) {
                Position = newPos;
                _lockTime = 0f;
            }

            return valid;
        }


        public void Initialize(Board board, Vector3Int position, TetrominoData data) {
            Board = board;
            Position = position;
            Data = data;
            RotationIndex = 0;
            _stepTime = Time.time + stepDelay;
            _lockTime = 0f;

            if (Cells == null) {
                Cells = new Vector3Int[data.Cells.Length];
            }

            for (int i = 0; i < data.Cells.Length; i++) {
                Cells[i] = (Vector3Int)data.Cells[i];
            }
        }

        private void Rotate(int direction) {
            var originalRotation = RotationIndex;
            RotationIndex = Wrap(RotationIndex + direction, 0, 4);
            ApplyRotationMatrix(direction);


            if (!TestWallKicks(RotationIndex, direction)) {
                RotationIndex = originalRotation;
                ApplyRotationMatrix(-direction);
            }
        }

        private void ApplyRotationMatrix(int direction) {
            for (int i = 0; i < Cells.Length; i++) {
                Vector3 cell = Cells[i];
                int x;
                int y;
                switch (Data.Tetromino) {
                    case Tetromino.I:
                    case Tetromino.O:
                        cell.x -= 0.5f;
                        cell.y -= 0.5f;
                        x = Mathf.CeilToInt((cell.x * Scripts.Data.RotationMatrix[0] * direction) +
                                            (cell.y * Scripts.Data.RotationMatrix[1] * direction));
                        y = Mathf.CeilToInt((cell.x * Scripts.Data.RotationMatrix[2] * direction) +
                                            (cell.y * Scripts.Data.RotationMatrix[3] * direction));
                        break;
                    default:
                        x = Mathf.RoundToInt((cell.x * Scripts.Data.RotationMatrix[0] * direction) +
                                             (cell.y * Scripts.Data.RotationMatrix[1] * direction));
                        y = Mathf.RoundToInt((cell.x * Scripts.Data.RotationMatrix[2] * direction) +
                                             (cell.y * Scripts.Data.RotationMatrix[3] * direction));
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

        private bool TestWallKicks(int rotationIndex, int rotDir) {
            int wallKickIndex = GetWallKickIndex(rotationIndex, rotDir);
            for (int i = 0; i < Data.wallKicks.GetLength(1); i++) {
                var translation = Data.wallKicks[wallKickIndex, i];

                if (Move(translation)) {
                    return true;
                }
            }

            return false;
        }

        private int GetWallKickIndex(int rotationIndex, int rotDir) {
            int wallKickIndex = rotationIndex * 2;

            if (rotationIndex < 0) {
                wallKickIndex--;
            }

            return Wrap(wallKickIndex, 0, Data.wallKicks.GetLength(0));
        }
    }
}