using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceGame.Scripts {
    public class Spawner : MonoBehaviour {

        [SerializeField] private float maxPos;
        [SerializeField] private Vector2 spawnPos;
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private float interval;


        private void Start() {
            StartCoroutine(EnemySpawner());
        }

        private Vector2 CalculateRandomSpawnPos() {
            
            spawnPos.y = Random.Range(-maxPos, maxPos);
            return spawnPos;
        }

        private IEnumerator EnemySpawner() {
            
            Instantiate(enemies[Random.Range(0, enemies.Length)], CalculateRandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(interval);
            StartCoroutine(EnemySpawner());
        }
    }
}
