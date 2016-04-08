using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameObject restartDialog;
	public GameObject completedDialog;
	public GameObject gameCompletedDialog;
	public GameObject quickRestartDialog;
	
	private bool paused;

	public bool Paused {

		get { return paused;}
	}

	private static SceneManager instance;

	public static SceneManager Instance {

		get {
			if (instance == null) {

				instance = GameObject.FindObjectOfType<SceneManager>();
			}

			return SceneManager.instance;
		}

	}
	
	// Use this for initialization
	void Start () {

		restartDialog.SetActive (false);
		completedDialog.SetActive (false);
		gameCompletedDialog.SetActive (false);
		quickRestartDialog.SetActive (false);
	
	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.P)) {
			if (!isShowQuickRestartDialog()) {
				quickRestartDialog.SetActive(true);
			} else {
				quickRestartDialog.SetActive(false);
			}

		}


	}

	public void ShowRestartDialog () {

		restartDialog.SetActive (true);
		
	}

	public void ShowCompletedDialog () {

		completedDialog.SetActive (true);
	}

	public void ShowGameCompletedDialog () {

		gameCompletedDialog.SetActive (true);
	}

	public void RestartGame() {

		Application.LoadLevel (Application.loadedLevelName);
	}

	public void QuitToMenu () {

		Application.LoadLevel ("Main_Menu");
	}

	public bool isShowDialog() {

		return restartDialog.activeSelf;
	}

	public bool isShowQuickRestartDialog() {

		return quickRestartDialog.activeSelf;
	}

	public void PauseGame() {

		paused = !paused;
	}

	public void ToNextLevel() {

		Application.LoadLevel (Application.loadedLevel + 1);
	}


}
