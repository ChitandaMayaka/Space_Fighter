using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	// Variable to store enemy type
	public GameObject enemy;

	// Variable for different spawn time
	public float spawnTime;

	public float spawnTimeAtBegin;

	public int counter;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("spawnEnemy", spawnTimeAtBegin, spawnTime);


	}
	
	// Spawn enemy
	void spawnEnemy () {

		var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		
		// Randomly pick a point within the spawn object
		var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy, spawnPoint, Quaternion.identity);

		counter--;


	}

	void Update() {
		if (counter <= 0) {
			CancelInvoke("spawnEnemy");
			
		}


		if (FindObjectOfType<SceneManager> ().isShowDialog ()) {

			CancelInvoke ("spawnEnemy");

		}
	}

}
