using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Scripts {
    public static class Data {
        private static readonly float Cos = Mathf.Cos(Mathf.PI / 2f);
        private static readonly float Sin = Mathf.Sin(Mathf.PI / 2f);
        public static readonly float[] RotationMatrix = { Cos, Sin, -Sin, Cos };
        
        public static readonly Dictionary<Tetromino, Vector2Int[]> Cells;
        static Data() {
            var iCells = new Vector2Int[] { new(-1, 1), new(0, 1), new(1, 1), new(2, 1) };
            var jCells = new Vector2Int[] { new(-1, 1), new(-1, 0), new(0, 0), new(1, 0) };
            var lCells = new Vector2Int[] { new(1, 1), new(-1, 0), new(0, 0), new(1, 0) };
            var oCells = new Vector2Int[] { new(0, 1), new(1, 1), new(0, 0), new(1, 0) };
            var sCells = new Vector2Int[] { new(0, 1), new(1, 1), new(-1, 0), new(0, 0) };
            var tCells = new Vector2Int[] { new(0, 1), new(-1, 0), new(0, 0), new(1, 0) };
            var zCells = new Vector2Int[] { new(-1, 1), new(0, 1), new(0, 0), new(1, 0) };

            Cells = new() {
                { Tetromino.I, iCells },
                { Tetromino.J, jCells },
                { Tetromino.L, lCells },
                { Tetromino.O, oCells },
                { Tetromino.S, sCells },
                { Tetromino.T, tCells },
                { Tetromino.Z, zCells },
            };
        }

        private static readonly Vector2Int[,] WallContactForI = {
            { new(0, 0), new(-2, 0), new( 1, 0), new(-2,-1), new( 1, 2) },
            { new(0, 0), new( 2, 0), new(-1, 0), new( 2, 1), new(-1,-2) },
            { new(0, 0), new(-1, 0), new( 2, 0), new(-1, 2), new( 2,-1) },
            { new(0, 0), new( 1, 0), new(-2, 0), new( 1,-2), new(-2, 1) },
            { new(0, 0), new( 2, 0), new(-1, 0), new( 2, 1), new(-1,-2) },
            { new(0, 0), new(-2, 0), new( 1, 0), new(-2,-1), new( 1, 2) },
            { new(0, 0), new( 1, 0), new(-2, 0), new( 1,-2), new(-2, 1) },
            { new(0, 0), new(-1, 0), new( 2, 0), new(-1, 2), new( 2,-1) },
        };
        
        

        private static readonly Vector2Int[,] WallContactForNonIType = {
            { new(0, 0), new(-1, 0), new(-1, 1), new(0,-2), new(-1,-2) },
            { new(0, 0), new( 1, 0), new( 1,-1), new(0, 2), new( 1, 2) },
            { new(0, 0), new( 1, 0), new( 1,-1), new(0, 2), new( 1, 2) },
            { new(0, 0), new(-1, 0), new(-1, 1), new(0,-2), new(-1,-2) },
            { new(0, 0), new( 1, 0), new( 1, 1), new(0,-2), new( 1,-2) },
            { new(0, 0), new(-1, 0), new(-1,-1), new(0, 2), new(-1, 2) },
            { new(0, 0), new(-1, 0), new(-1,-1), new(0, 2), new(-1, 2) },
            { new(0, 0), new( 1, 0), new( 1, 1), new(0,-2), new( 1,-2) },
        };
        
        
        
        public static readonly Dictionary<Tetromino, Vector2Int[,]> TetrominoWallContact = new() {
            { Tetromino.I, WallContactForI },
            { Tetromino.J, WallContactForNonIType },
            { Tetromino.L, WallContactForNonIType },
            { Tetromino.O, WallContactForNonIType },
            { Tetromino.S, WallContactForNonIType },
            { Tetromino.T, WallContactForNonIType },
            { Tetromino.Z, WallContactForNonIType },
        };
    }
}
