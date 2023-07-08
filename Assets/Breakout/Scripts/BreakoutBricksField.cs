using UnityEngine;

namespace Breakout.Scripts {
    public class BreakoutBricksField : MonoBehaviour
    {
        [SerializeField] private int height;
        [SerializeField] private int width;
        [SerializeField] private float threshold;
        [SerializeField] private GameObject brickPrefab;
        [SerializeField] private Material[] brickColors;

        private void Start() {

            for (int x = 0; x < width; x++) {
            
                for (int y = 0; y < height; y++) {
               
                    brickPrefab.GetComponent<SpriteRenderer>().material = brickColors[y];
                    var brick = Instantiate(brickPrefab, gameObject.transform);
                    brick.transform.localPosition = new Vector3(x + threshold * x, y);
                }
            }
        }
    }
}
