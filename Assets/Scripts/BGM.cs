using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.M)) {

			GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
		}
	
	}
}
