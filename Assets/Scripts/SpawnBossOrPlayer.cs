using UnityEngine;
using System.Collections;

public class SpawnBossOrPlayer : MonoBehaviour {
	
	// Variable to gameobject type
	public GameObject bossOrPlayer;
		
	// Variable for when to spawn
	public float spawnTime;
		
	// Use this for initialization
	void Start () {
			
		Invoke ("spawnBossOrPlayer", spawnTime);
			
	}
		
	// Spawn enemy
	void spawnBossOrPlayer () {
			
		// Spawn boss in the center
		var spawnPoint = new Vector2(transform.position.x, transform.position.y);
			
		// Create an enemy at the 'spawnPoint' position
		Instantiate(bossOrPlayer, spawnPoint, Quaternion.identity);

	}

	void Update() {

		if (FindObjectOfType<SceneManager> ().isShowDialog ()) {

			CancelInvoke("spawnBossOrPlayer");
		}
	}



		

}
