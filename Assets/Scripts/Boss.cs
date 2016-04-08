using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	// Spaceship component
	Spaceship spaceship;
	Vector2 direction;
	public int hp;
	public int point;
	IEnumerator Start() {

		//Let player ready
		// Get Spaceship component
		spaceship = GetComponent<Spaceship> ();
		
		// Move in negative Y forward
		direction = transform.up * -1;
		spaceship.Move (direction);
		
		// If cannot shot, end the coroutine
		if (spaceship.canShot == false) {
			yield break;
		}
		//Let player ready
		yield return new WaitForSeconds (3);

		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild (i);
				spaceship.Shot (shotPosition);
			}
			
			yield return new WaitForSeconds (spaceship.shotDelay); 
			
		}

		
	}
	
	void OnTriggerEnter2D (Collider2D c) {
		// Get the Layer name
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// Collision with top & bottom NonBossArea
		if (layerName == "NonBossAreaTB") {
			direction.y = direction.y * -1;
		}

		// Collision with left & right NonBossArea
		if (layerName == "NonBossAreaLR") {
			direction.x = direction.x * -1;
		}
		
		// Delete the bullet, if it's in Bullet(Player) layout
		if (layerName == "Bullet(Player)") {
			
			// Get the Bullet component
			Bullet bullet =  c.GetComponent<Bullet>();
			
			// Deduct the hit points
			hp = hp - bullet.ap;
			
			// Delete the bullet
			Destroy(c.gameObject);
			
			// if the hit points fall to 0 or less…
			if(hp <= 0 )
			{
				FindObjectOfType<Score>().AddScore(point);
				// Explode
				spaceship.Explosion ();
				
				// Delete the enemy
				Destroy (gameObject);

				FindObjectOfType<SceneManager>().ShowCompletedDialog();
			}
		}

	}
	

	void Update () {

			if (hp == 250) {
				direction.x = 1;
			}
			spaceship.Move (direction);



	}

	
}
