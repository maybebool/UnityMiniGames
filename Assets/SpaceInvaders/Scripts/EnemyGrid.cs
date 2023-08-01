using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders.Scripts {
    public class EnemyGrid : MonoBehaviour {
    
        public static EnemyGrid Instance;
    
        [SerializeField] private RegularEnemy[] prefabs;
        [SerializeField] private float speed;
        [SerializeField] private int rows = 5;
        [SerializeField] private int columns = 10;
    
        private List<RegularEnemy> _currentArmyCount = new();
        private Vector3 _direction = Vector3.right;
        private Camera _camera;
        private float _enemyBulletSpawnRate = 2f;

        private void Awake() {
            _camera = Camera.main;


            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = this;
            }
        }


        private void Update() {
            var leftBorder = _camera.ViewportToWorldPoint(Vector3.zero);
            var rightBorder = _camera.ViewportToWorldPoint(Vector3.right);
            transform.position += _direction * (speed * Time.deltaTime);


            if (_direction == Vector3.right && transform.position.x >= rightBorder.x - 11f) {
                GridMovement();
            }
            else if (_direction == Vector3.left && transform.position.x <= leftBorder.x + 11f) {
                GridMovement();
            }

            if (_currentArmyCount.Count <= 0) {
                SIGameManager.Instance.GameOverScreen();
            }
        }

        private void Start() {
            GenerateEnemyGrid();
            StartCoroutine(RandomEnemyBulletSpawner());
        }


        private IEnumerator RandomEnemyBulletSpawner() {
            while (true) {
                var rnd = Random.Range(1, 3);
                yield return new WaitForSeconds(rnd);
                var enemyRandomPicker = Random.Range(0, _currentArmyCount.Count);
                _currentArmyCount[enemyRandomPicker].ShootBullet();
            }
        }


        private void GridMovement() {
            _direction = new Vector3(-_direction.x, 0f, 0f);
            var position = transform.position;
            position.y -= 1f;
            transform.position = position;
        }


        private void GenerateEnemyGrid() {
            var width = 2f * (columns - 1);
            var height = 2f * (rows - 1);

            for (int i = 0; i < rows; i++) {
                var screenCenter = new Vector2(-width * 0.5f, -height * 0.5f); // center 
                var rowPosition = new Vector3(screenCenter.x, (2f * i) + screenCenter.y, 0f);
                for (int j = 0; j < columns; j++) {
                    var enemy = Instantiate(prefabs[i], transform);
                    _currentArmyCount.Add(enemy);
                    var position = rowPosition;
                    position.x += 2f * j;
                    enemy.transform.localPosition = position;
                }
            }
        }

        public void CorrectingCurrentArmyCount(RegularEnemy enemy) {
            _currentArmyCount.Remove(enemy);
        }
    }
}