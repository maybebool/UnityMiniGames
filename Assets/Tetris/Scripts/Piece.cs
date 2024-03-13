using UnityEngine;
namespace Tetris.Scripts {
    public class Piece : MonoBehaviour {
        private Board Board { get; set; }
        public TetrominoData Data { get; private set; }
        public Vector3Int[] Cells { get; private set; }
        public Vector3Int Position { get; private set; }

        private int RotationIndex { get; set; }

        public float stepDelay = 1f;
        public float lockDelay = .5f;
        private float _stepTime;
        private float _lockTime;


        private void Update() {
            Board.Clear(this);
            _lockTime += Time.deltaTime;
            
            CheckUserInput();
            if (Time.time >= _stepTime) {
                Step();
            }
            Board.Set(this);
        }

        private void CheckUserInput() {
            if (!Input.anyKeyDown) return;
            var pressedKey = Input.inputString[0];
            switch (pressedKey) {
                case 'q':
                    Rotate(-1);
                    break;
                case 'e':
                    Rotate(1);
                    break;
                case 'a':
                    MovePieces(Vector2Int.left);
                    break;
                case 'd':
                    MovePieces(Vector2Int.right);
                    break;
                case 's':
                    MovePieces(Vector2Int.down);
                    break;
                case ' ':
                    LetPieceFall();
                    break;
            }
        }

        private void Step() {
            _stepTime = Time.time + stepDelay;
            MovePieces(Vector2Int.down);
            if (_lockTime >= lockDelay) {
                LockPieceInPosition();
            }
        }

        private void LockPieceInPosition() {
            Board.Set(this);
            Board.ClearLine();
            Board.SpawnPiece();
        }


        private void LetPieceFall() {
            while (MovePieces(Vector2Int.down)) {
            }
            LockPieceInPosition();
        }

        private bool MovePieces(Vector2Int translation) {
            var newPos = Position;
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

            // if Cells Array is empty it fills Cells with data
            Cells ??= new Vector3Int[data.Cells.Length];

            for (int i = 0; i < data.Cells.Length; i++) {
                Cells[i] = (Vector3Int)data.Cells[i];
            }
        }

        private void Rotate(int direction) {
            var originalRotation = RotationIndex;
            RotationIndex = Wrap(RotationIndex + direction, 0, 4);
            ApplyRotationMatrix(direction);


            if (CheckForWallContact(RotationIndex)) return;
            RotationIndex = originalRotation;
            ApplyRotationMatrix(-direction);
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

            return min + (input - min) % (max - min);
        }

        private bool CheckForWallContact(int rotationIndex) {
            var wallKickIndex = GetWallContactIndex(rotationIndex);
            for (int i = 0; i < Data.wallKicks.GetLength(1); i++) {
                var translation = Data.wallKicks[wallKickIndex, i];

                if (MovePieces(translation)) {
                    return true;
                }
            }

            return false;
        }

        private int GetWallContactIndex(int rotationIndex) {
            var wallContactsIndex = rotationIndex * 2;

            if (rotationIndex < 0) {
                wallContactsIndex--;
            }

            return Wrap(wallContactsIndex, 0, Data.wallKicks.GetLength(0));
        }
    }
}