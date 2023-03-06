using UnityEngine;
using Random = UnityEngine.Random;


namespace DoodleJump.Scripts {
	public class Destroy : MonoBehaviour {
		[SerializeField] private GameObject player;
		[SerializeField] private GameObject platform;
		[SerializeField] private GameObject spring;
		private GameObject myPlat;


		private void OnTriggerEnter2D(Collider2D col) {


			if (col.gameObject.name.StartsWith("Platform")) {
				if (Random.Range(1, 10) == 1) {
					
					Destroy(col.gameObject);
					Instantiate(spring,
						new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (2 + Random.Range(0.2f, 1f))),
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
						new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (2 + Random.Range(0.2f, 1f))),
						Quaternion.identity);
				}
			}
		}
	}
}