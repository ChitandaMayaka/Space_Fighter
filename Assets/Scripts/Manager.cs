using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	

	public void PlayGame() {
		
		Application.LoadLevel ("Level1");
	}
	
	public void QuitGame() {
		
		Application.Quit ();
	}
	
	public void SelectLevel() {
		
		Application.LoadLevel ("SelectLevel");
	}

	public void LoadLevel1() {

		Application.LoadLevel ("Level1");
	}

	public void LoadLevel2() {
		
		Application.LoadLevel ("Level2");
	}

	public void LoadLevel3() {
		
		Application.LoadLevel ("Level3");
	}

	public void ToInstruction () {

		Application.LoadLevel ("Instruction");
	}

	public void QuitToMenu () {

		Application.LoadLevel ("Main_Menu");
	}
}
