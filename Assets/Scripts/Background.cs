using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	// Scrolling Speed
	public float speed = 0.1f;
	
	void Update ()
	{
		// Y will go from 0 to 1 as time goes on. When the Y value is 1, it will return to 0.
		float y = Mathf.Repeat (Time.time * speed, 0.3f);
		
		// Make an offset value for the Y value
		Vector2 offset = new Vector2 (0, y);
		
		// Set the material offset.
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
