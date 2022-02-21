using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void onPlay()
	{
		SceneManager.LoadScene(1);
	}

	public void onMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void onAchievements()
	{
		SceneManager.LoadScene(2);
	}

	public void onQuit()
	{
		Application.Quit();
	}
}
