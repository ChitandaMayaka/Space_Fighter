using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// hit points
	public int hp;

	public int point;
	// Spaceship component
	Spaceship spaceship;
	// Use this for initialization
	IEnumerator Start() {
		// Get Spaceship component
		spaceship = GetComponent<Spaceship> ();
		if (!SceneManager.Instance.Paused) {

			// Move in negative Y forward
			spaceship.Move (transform.up * -1);
		}
			
			// If cannot shot, end the coroutine
		if (spaceship.canShot == false) {
				yield break;
		}
			
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
		
		// Return immediately if the layer is not “Bullet (Player)”
		if( layerName != "Bullet(Player)") return;
		
		// Get the Bullet component
		Bullet bullet = c.GetComponent<Bullet>();
		
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
		}
	}

}
