using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menu_selection : MonoBehaviour {

	void Update()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

	}
	public void LoadScene(string value)
	{
		switch (value) {
		case "play":
			SceneManager.LoadScene (1);
			break;
		case "retry":
			SceneManager.LoadScene (1);
			break;
		case "dead":
			SceneManager.LoadScene (2);
			break;
		case "menu":
			SceneManager.LoadScene (0);
			break;
		/*case "options":
			SceneManager.LoadScene (0);
			break;*/
		case "exit":
			Application.Quit ();
			break;
		}
	}
}
