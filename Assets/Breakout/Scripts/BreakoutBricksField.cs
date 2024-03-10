using UnityEngine;

namespace Breakout.Scripts {
    public class BreakoutBricksField : MonoBehaviour {
        
        [SerializeField] private int height;
        [SerializeField] private int width;
        [SerializeField] private float threshold;
        [SerializeField] private GameObject brickPrefab;
        [SerializeField] private Material[] brickColors;

        
        private void Start() {
            InitializeBricksGrid();
        }

        private void InitializeBricksGrid() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    InitializeBrick(x, y);
                }
            }
        }

        private void InitializeBrick(int x, int y) {
            brickPrefab.GetComponent<MeshRenderer>().material = GetBrickMaterialColor(y);
            var brick = Instantiate(brickPrefab, gameObject.transform);
            brick.transform.localPosition = new Vector3(x + threshold * x, y);
        }

        private Material GetBrickMaterialColor(int index) {
            if (index >= 0 && index < brickColors.Length) {
                return brickColors[index];
            }
            // return default color
            return brickColors[0];
        }
    }
}