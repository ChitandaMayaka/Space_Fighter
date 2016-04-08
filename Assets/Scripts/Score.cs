using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score;

	private int previousLevel;

	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text>();
		previousLevel = PlayerPrefs.GetInt ("preLevel", 2);
		if (Application.loadedLevel == 2 || Application.loadedLevel == 1 || Application.loadedLevel == previousLevel) {

			score = 0;
		} else {
			score = PlayerPrefs.GetInt ("Score", 0);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		previousLevel = Application.loadedLevel;
		PlayerPrefs.SetInt ("preLevel", previousLevel);
		text.text = "Score: " + score;
		PlayerPrefs.SetInt ("Score", score);
	
	}

	public void AddScore (int point) {

		score = score + point;

	}
	
}
