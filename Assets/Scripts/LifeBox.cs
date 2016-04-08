using UnityEngine;
using System.Collections;

public class LifeBox : MonoBehaviour {

	public float speed;

	void Start() {

		GetComponent<Rigidbody2D> ().velocity = transform.up * -1 * speed;

	}
	
}
