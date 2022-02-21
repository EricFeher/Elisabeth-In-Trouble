using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Achievements
{
	public string name;
	public Image visual = null;
}

public class AchievementManager : MonoBehaviour
{
	public Achievements[] ac;
	public Sprite unlockedImage=null;
	public Sprite lockedImage=null;


	private void Start()
	{
		if (unlockedImage != null)
		{
			AchievementVisualInit();
		}
	}
	public void ManageAchievement(string achii)
	{
		if (PlayerPrefs.GetInt(achii) == 0)
		{
			PlayerPrefs.SetInt(achii, 1);
			Debug.Log(achii + " hozzáadva");
		}
		else
		{
			Debug.Log(achii + " már elérve");
		}
	}

	public void clearAchievemnts()
	{
		foreach (Achievements element in ac)
		{
			PlayerPrefs.DeleteKey(element.name);
		}
		AchievementVisualInit();
	}

	public void AchievementVisualInit()
	{
		foreach (Achievements element in ac)
		{
			if (element.visual != null && PlayerPrefs.GetInt(element.name, 0) != 0)
			{
				element.visual.sprite = unlockedImage;
			}

			if (element.visual != null && PlayerPrefs.GetInt(element.name, 0) == 0)
			{
				element.visual.sprite = lockedImage;
			}
		}
	}
}
