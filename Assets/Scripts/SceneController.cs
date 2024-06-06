using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class SceneController : MonoBehaviour
{
	public GameObject SceneSelectionMenu;
	public GameObject MainSplashScreen; // Gameobject to show while the system is starting up. Will be some kind of animation
	public Scene CurrentScene;
	public Camera MainCamera;
	public float MenuDistance = 2f;
	public GameObject PlayerXROrigin;

	private void Start()
	{
		ToggleSplashScreen(false);
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		ShowSceneSelectMenu();
  }

	public void ToggleSceneSelectMenu()
	{
		if (SceneSelectionMenu.activeSelf)
			SceneSelectionMenu.SetActive(false);
		else
		{
			ShowSceneSelectMenu();
		}
	}

	public void HideSceneSelectMenu()
	{
		SceneSelectionMenu.SetActive(false);
	}

	public void ShowSceneSelectMenu()
	{
		SceneSelectionMenu.transform.position = MainCamera.transform.position + 
																						MainCamera.transform.forward * MenuDistance;
		SceneSelectionMenu.SetActive(true);
	}

	public void ToggleSplashScreen(bool Active)
	{
		if (MainSplashScreen != null)
		{
			MainSplashScreen.SetActive(Active);
		}
	}

	public void LoadScene(string sceneName)
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i).name != "MainScene")
				SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
		}

		ToggleSplashScreen(true);

		// Load the selected scene
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

		// Align the scene Plane to the camera

		// Hide the Scene Selection Menu
		HideSceneSelectMenu();
	}

	private void SceneManager_sceneLoaded(Scene SceneLoaded, LoadSceneMode LoadedMode)
	{
		if (SceneLoaded.name != "MainScene")
		{
			CurrentScene = SceneLoaded;
		}
		if (!SceneManager.SetActiveScene(SceneLoaded))
		{
			Debug.Log("Scene not active" + SceneLoaded.name);
		}
		PlayerXROrigin.transform.position = new Vector3(0, 0, 0);
		ToggleSplashScreen(false);
	}

	public void ExitApplication()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}

}
