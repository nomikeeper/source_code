using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class menu_play : MonoBehaviour {


	public void LoadScene(string value)
	{
		switch (value) {
		case "play":
			SceneManager.LoadScene (2);
			break;
		case "retry":
			SceneManager.LoadScene (2);
			break;
		case "dead":
			SceneManager.LoadScene (1);
			break;
		case "menu":
			SceneManager.LoadScene (0);
			break;
		}
	}
}
