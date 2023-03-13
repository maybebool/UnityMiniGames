using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;


namespace DoodleJump.Scripts {
	public class Destroy : MonoBehaviour {
		[SerializeField] private GameObject player;
		[SerializeField] private GameObject platform;
		[SerializeField] private GameObject spring;
		// [SerializeField] private bool usePool;
		// private ObjectPool<GameObject> _pool;
		private GameObject myPlat;

		// private void Start() {
		// 	_pool = new ObjectPool<GameObject>(() => {
		// 		return Instantiate(platform);
		// 	}, o => {
		// 		gameObject.SetActive(true);
		// 	}, o => {
		// 		gameObject.SetActive(false);
		// 	}, o => {
		// 		Destroy(this.gameObject);
		// 	}, false, 10, 20);
		// }


		private void OnTriggerEnter2D(Collider2D col) {


			if (col.gameObject.name.StartsWith("Platform")) {
				if (Random.Range(1, 10) == 1) {
					
					Destroy(col.gameObject);
					Instantiate(spring,
						new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + ( Random.Range(0.2f, 1f))),
						Quaternion.identity);
				}
				else {
					col.gameObject.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f),
						player.transform.position.y + (2 + Random.Range(0.2f, 1f)));
				}
			}
			else if (col.gameObject.name.StartsWith("Spring")) {
				if (Random.Range(1, 10) == 1) {
					col.gameObject.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f),
						player.transform.position.y + (2 + Random.Range(0.2f, 1f)));
				}
				else {
					Destroy(col.gameObject);
					Instantiate(platform,
						new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (Random.Range(0.2f, 1f))),
						Quaternion.identity);
				}
			}
		}


		private void KillPlatform(GameObject platf){
			// if (usePool) {
			// 	_pool.Release(platf);
			// }
			// else {
				Destroy(this.gameObject);
			// }
		}
	}
}