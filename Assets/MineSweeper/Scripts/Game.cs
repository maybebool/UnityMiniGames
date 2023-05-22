using System;
using UnityEngine;

namespace MineSweeper.Scripts
{
    public class Game : MonoBehaviour
    {
        public int width = 16;
        public int height = 16;

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

        private void NewGame()
        {
            _state = new Cell[width, height];
            GenerateCells();
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
    }
}
