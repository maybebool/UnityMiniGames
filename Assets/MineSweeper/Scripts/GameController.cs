using System;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace MineSweeper.Scripts {
    public class GameController : MonoBehaviour {
        [SerializeField] private int width = 16;
        [SerializeField] private int height = 16;
        [SerializeField] private int mineCount = 32;

        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject uiPanel;
        [SerializeField] private TMP_Text wonText;
        [SerializeField] private TMP_Text gameOverText;

        private GridBoard _board;
        private Cell[,] _state;
        private bool _gameOver;
        private Camera _mainCam;

        private void OnValidate() {
            mineCount = Mathf.Clamp(mineCount, 0, width * height);
        }

        private void Awake() {
            _mainCam = Camera.main;
            Application.targetFrameRate = 60;

            _board = GetComponentInChildren<GridBoard>();
        }

        private void OnEnable() {
            restartButton.onClick.AddListener(NewGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable() {
            restartButton.onClick.RemoveListener(NewGame);
            quitButton.onClick.RemoveListener(QuitGame);
        }

        private void Start() {
            NewGame();
        }

        private void Update() {
            if (!_gameOver) {
                if (Input.GetMouseButtonDown(1)) {
                    FlagCellAtMousePosition();
                }
                else if (Input.GetMouseButtonDown(0)) {
                    Reveal();
                }
            }
        }
        private void NewGame() {
            DisableUI();
            _state = new Cell[width, height];
            _gameOver = false;

            GenerateCells();
            GenerateMines();
            GenerateNumbers();

            _mainCam.transform.position = new Vector3(width / 2f, height / 2f, -10f);
            _board.Draw(_state);
        }

        private void QuitGame() {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }

        private void DisableUI() {
            uiPanel.SetActive(false);
            wonText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
        }

        private void GenerateCells() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var cell = new Cell();
                    cell.position = new Vector3Int(x, y, 0);
                    cell.type = Cell.Type.Empty;
                    _state[x, y] = cell;
                }
            }
        }

        private void GenerateMines() {
            for (int i = 0; i < mineCount; i++) {
                var x = Random.Range(0, width);
                var y = Random.Range(0, height);

                while (_state[x, y].type == Cell.Type.Mine) {
                    x++;

                    if (x >= width) {
                        x = 0;
                        y++;

                        if (y >= height) {
                            y = 0;
                        }
                    }
                }

                _state[x, y].type = Cell.Type.Mine;
            }
        }

        private void GenerateNumbers() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var cell = _state[x, y];

                    if (cell.type == Cell.Type.Mine) {
                        continue;
                    }

                    cell.number = CountMines(x, y);

                    if (cell.number > 0) {
                        cell.type = Cell.Type.Number;
                    }

                    _state[x, y] = cell;
                }
            }
        }

        private int CountMines(int cellX, int cellY) {
            var count = 0;

            for (int adjacentX = -1; adjacentX <= 1; adjacentX++) {
                for (int adjacentY = -1; adjacentY <= 1; adjacentY++) {
                    if (adjacentX == 0 && adjacentY == 0) {
                        continue;
                    }

                    var x = cellX + adjacentX;
                    var y = cellY + adjacentY;

                    if (GetCell(x, y).type == Cell.Type.Mine) {
                        count++;
                    }
                }
            }

            return count;
        }
        
        private Cell GetCellAtMousePosition() {
            var worldPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            var cellPosition = _board.TileMap.WorldToCell(worldPosition);
            return GetCell(cellPosition.x, cellPosition.y);
        }

        private void UpdateCellStateAndRedraw(int x, int y, Cell cell) {
            _state[x, y] = cell;
            _board.Draw(_state);
        }

        private void FlagCellAtMousePosition() {
            var cell = GetCellAtMousePosition();

            // Cannot flag if already revealed
            if (cell.type == Cell.Type.Invalid || cell.revealed) return;

            cell.flagged = !cell.flagged;
            UpdateCellStateAndRedraw(cell.position.x, cell.position.y, cell);
        }

        private void Reveal() {
            var cell = GetCellAtMousePosition();

            // Cannot reveal if already revealed or while flagged
            if (cell.type == Cell.Type.Invalid || cell.revealed || cell.flagged) return;

            switch (cell.type) {
                case Cell.Type.Mine:
                    Explode(cell);
                    break;
                case Cell.Type.Empty:
                    StartSpreadingCells(cell);
                    CheckWinCondition();
                    break;
                
                default:
                    cell.revealed = true;
                    CheckWinCondition();
                    break;
            }

            UpdateCellStateAndRedraw(cell.position.x, cell.position.y, cell);
        }

        private void StartSpreadingCells(Cell cell) {
            if (cell.revealed) return;
            if (cell.type is Cell.Type.Mine or Cell.Type.Invalid) return;
            cell.revealed = true;
            _state[cell.position.x, cell.position.y] = cell;
            // Keep spreading if the cell is empty, otherwise stop at numbers
            if (cell.type == Cell.Type.Empty) {
                SpreadToNeighbourCells(cell);
            }
        }

        private void SpreadToNeighbourCells(Cell cell) {
            // Spread the reveal operation to the neighboring cells
            StartSpreadingCells(GetCell(cell.position.x - 1, cell.position.y));
            StartSpreadingCells(GetCell(cell.position.x + 1, cell.position.y));
            StartSpreadingCells(GetCell(cell.position.x, cell.position.y - 1));
            StartSpreadingCells(GetCell(cell.position.x, cell.position.y + 1));
        }
        
        private void Explode(Cell cell) {
            //Debug.Log("Game Over!");
            _gameOver = true;
            uiPanel.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            SetCellState(cell, true, true);
    
            // Reveal all other mines
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var currentCell = _state[x, y];
                    if (currentCell.type == Cell.Type.Mine) {
                        SetCellState(currentCell, true);
                    }
                }
            }
        }

        private void SetCellState(Cell cell, bool isRevealed, bool hasExploded = false) {
            cell.exploded = hasExploded;
            cell.revealed = isRevealed;
            _state[cell.position.x, cell.position.y] = cell;
        }

        private bool AllNonMineCellsRevealed() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var cell = _state[x, y];
                    if (cell.type != Cell.Type.Mine && !cell.revealed) {
                        return false;
                    }
                }
            }

            return true;
        }

        private void CheckWinCondition() {
            if (!AllNonMineCellsRevealed()) {
                return; // no win
            }

            //Debug.Log("Winner!");
            _gameOver = true;
            uiPanel.SetActive(true);
            wonText.gameObject.SetActive(true);

            // Flag all the mines
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var cell = _state[x, y];
                    if (cell.type == Cell.Type.Mine) {
                        cell.flagged = true;
                        _state[x, y] = cell;
                    }
                }
            }
        }

        private Cell GetCell(int x, int y) {
            return IsValid(x, y) ? _state[x, y] : new Cell();
        }

        private bool IsValid(int x, int y) {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }
}