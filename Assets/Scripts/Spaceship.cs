using UnityEngine;
///Require the Rigidbody2D component.
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
	// Movement Speed
	public float speed;
	
	// Bullet Firing Delay
	public float shotDelay;
	
	// Bullet Prefab
	public GameObject bullet;

	// Wether the enemy can shot
	public bool canShot;

	// Explosion Prefab
	public GameObject explosion;

	// Make a explosion
	public void Explosion() {
		Instantiate (explosion, transform.position, transform.rotation);
	}
	
	
	// Create a bullet
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}
	
	// Move the ship
	public void Move (Vector2 direction)
	{
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}