using UnityEngine;

namespace MineSweeper.Scripts {
    public struct Cell {
        public enum Type {
            Invalid,
            Empty,
            Mine,
            Number
        }

        public Type type;
        public Vector3Int position;
        public int number;
        public bool revealed;
        public bool flagged;
        public bool exploded;
    }
}