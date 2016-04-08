using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	public static int highScore;

	private string highScoreKey = "highScoreKey";
	
	Text text;
	
	// Use this for initialization
	void Start () {
		
		text = GetComponent<Text> ();
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (highScore < Score.score) {
			highScore = Score.score;
		}
		
		text.text = "HighScore: " + highScore;
		
	}
	
	public void Save() {
		
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		
		Start ();
	}
}
