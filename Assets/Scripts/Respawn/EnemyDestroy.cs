using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
	public int life = 2;
	public Transform fallDeathCheck;

	virtual protected void Update()
	{
		if (transform.position.y < fallDeathCheck.position.y)
		{
			this.gameObject.SetActive(false);
		}
		return;
	}


	virtual public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Weapon")
		{
			life--;
			if (life <= 0)
			{
				AudioManager.instance.PlaySound("EnemyDeath");
				if (this.gameObject.name.Equals("BasicGhost"))
				{
					BasicEnemyDestroy.deaths++;
				}
				if (BasicEnemyDestroy.deaths == 3)
				{
					GameObject.FindGameObjectWithTag("GameController").GetComponent<AchievementManager>().ManageAchievement("Ghost");
				}
				this.gameObject.SetActive(false);
			}
			else
			{
				AudioManager.instance.PlaySound("Hurt");
			}
		}
	}

}
