using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace MineSweeper.Scripts
{
    public class Game : MonoBehaviour
    {
        public int width = 16;
        public int height = 16;
        public int mineCount = 32;

        private MS_Board _board;
        private Cell[,] _state;
        private Camera _camera;

        private void Awake()
        {
            _board = GetComponentInChildren<MS_Board>();
            _camera = Camera.main;
        }

        private void Start()
        {
            NewGame();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Flag();
            }
        }

        private void Flag()
        {
            var worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var cellPosition = _board.Tilemap.WorldToCell(worldPosition);

            var cell = GetCell(cellPosition.x, cellPosition.y);
            if (cell.type == Cell.Type.Invalid || cell.revealed)
            {
                return;
            }

            cell.flagged = !cell.flagged;
            _state[cellPosition.x, cellPosition.y] = cell;
            _board.Draw(_state);
        }

        private Cell GetCell(int x, int y)
        {
            if (IsValid(x,y))
            {
                return _state[x, y];
            }

            return new Cell();
        }

        private bool IsValid(int x, int y)
        {
            return x < 0 || x >= width || y < 0 || y >= height;
        }

        private void NewGame() {
            _state = new Cell[width, height];
            GenerateCells();
            GenerateMines();
            GenerateNumbers();
            _camera.transform.position = new Vector3(width / 2f, height / 2f, -10f);
            _board.Draw(_state);
        }

        private void GenerateCells()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var cell = new Cell();
                    cell.position = new Vector3Int(x, y, 0);
                    cell.type = Cell.Type.Empty;
                    _state[x, y] = cell;
                }
            }
        }

        private void GenerateMines()
        {
            for (int i = 0; i < mineCount; i++)
            {
                var x = Random.Range(0, width);
                var y = Random.Range(0, height);

                while (_state[x,y].type == Cell.Type.Mine) {
                    
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
                //_state[x, y].revealed = true;
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

                    //cell.revealed = true;
                    _state[x, y] = cell;
                }
            }
        }

        private int CountMines(int cellX, int cellY)
        {
            var count = 0;
            for (int adjX = -1; adjX <= 1; adjX++) {
                for (int adjY = -1; adjY <= 1; adjY++) {

                    if (adjX == 0 && adjY == 0) {
                        continue;
                    }
                    var x = cellX + adjX;
                    var y = cellY + adjY;

                    if (x < 0 || x >= width || y < 0 || y >= height)
                    {
                        continue;
                    }

                    if (GetCell(x,y).type == Cell.Type.Mine)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
    }
}
