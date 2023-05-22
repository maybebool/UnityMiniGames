using System;
using UnityEngine;

namespace MineSweeper.Scripts
{
    public class Game : MonoBehaviour
    {
        public int width = 16;
        public int height = 16;

        private MS_Board board;
        private Cell[,] state;

        private void Awake()
        {
            board = GetComponentInChildren<MS_Board>();
            
        }

        private void Start()
        {
            NewGame();
        }

        private void NewGame()
        {
            state = new Cell[width, height];
            GenerateCells();
            board.Draw(state);
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
                    state[x, y] = cell;
                }
            }
        }
    }
}
