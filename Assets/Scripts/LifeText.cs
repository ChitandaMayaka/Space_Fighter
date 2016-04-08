using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeText : MonoBehaviour {

	public static int life;

	Text text;

	void Start() {

		text = GetComponent<Text> ();

		life = 3;

	}

	void Update() {

		text.text = life.ToString ();
	}

	public void LifeReduction() {

		life = life - 1;
		if (life < 0) {
			life = 0;
		}
	}

	public void  LifeAddition () {

		life = life + 1;
	}
}
