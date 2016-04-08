using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 10;

	public float lifeTime = 5;

	// attack power
	public int ap = 1;
	// Use this for initialization
	void Start () {

		if (!SceneManager.Instance.Paused) {
			GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
		}
		Destroy (gameObject, lifeTime);
		//GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

		//Destroy (gameObject, lifeTime);
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
