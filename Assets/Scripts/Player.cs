using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Movement Speed
	public float speed = 5;

	// Spaceship component
	Spaceship spaceship;

	public int life = 3;

	public AudioSource [] soundEffect;
	public AudioSource shoot;
	public AudioSource getLife;
	
	// Call a coroutine inside the Start method
	IEnumerator Start()
	{
		// Get Spaceships component
		spaceship = GetComponent<Spaceship> ();
		soundEffect = GetComponents<AudioSource> ();
		shoot = soundEffect [0];
		getLife = soundEffect [1];

		while (true) {
			// Make a bullet with the same position and rotation as the player
			spaceship.Shot (transform);
				
			// Play the shot sound effect
			shoot.Play ();
			//GetComponent<AudioSource>().Play();
				
			// wait for 0.05 seconds
			yield return new WaitForSeconds (spaceship.shotDelay);
		}

	}
	
	void Update ()
	{
		if (!SceneManager.Instance.Paused) {
			// Right, Left
			float x = Input.GetAxisRaw ("Horizontal");
			
			// Up, Down
			float y = Input.GetAxisRaw ("Vertical");
			
			// Get the direction of movement
			Vector2 direction = new Vector2 (x, y).normalized;
			
			// Move
			spaceship.Move (direction);
			
			// Restrict the movement
			Clamp ();
		}

	}
	void Clamp () {

		// Get the lower-left world coordinate of the viewport.
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		
		// Get the upper-right world coordinate of the viewport.
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		
		// Get the coordinates of the player
		Vector2 pos = transform.position;
		
		// Restrict the player from moving outside of the screen.
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		// Assign the newly-restricted position value.
		transform.position = pos;

	}
	void OnTriggerEnter2D (Collider2D c){
		// Get the Layer name
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// Get lifebox
		if (layerName == "LifeBox") {

			getLife.Play ();
			Destroy(c.gameObject);

			FindObjectOfType<LifeText>().LifeAddition();

		}
		
		// Delete the bullet, if it’s in the “Bullet (Enemy)” layer
		if( layerName == "Bullet(Enemy)")
		{
			// Delete the bullet
			Destroy(c.gameObject);

		}

		if ((layerName == "Bullet(Enemy)" || layerName == "Enemy" || layerName == "Boss") && LifeText.life < 1) {
			
			FindObjectOfType<LifeText>().LifeReduction();
			
			FindObjectOfType<SceneManager>().ShowRestartDialog();
			
			spaceship.Explosion();
			
			Destroy (gameObject);
			
		}
		
		// Create an explosion if the layer is “Bullet (Enemy)” or “Enemy”
		if( (layerName == "Bullet(Enemy)" || layerName == "Enemy" || layerName == "Boss") && LifeText.life >= 1)
		{
			// Explode

			FindObjectOfType<LifeText>().LifeReduction();
			spaceship.Explosion();

			Instantiate(gameObject);
			// Delete the player
			Destroy (gameObject);
		} 

	}

	public int GetLife() {
		return life;
	}
	
}
