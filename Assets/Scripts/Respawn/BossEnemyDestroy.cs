using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyDestroy : EnemyDestroy
{
	private bool phase = false;
	private int basicLife;
	protected void Start()
	{
		basicLife = base.life;
	}
	protected override void Update()
	{
		base.Update();
		return;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
		if (base.life <= basicLife / 2 && !phase)
		{
			this.GetComponent<BossGhostAI>().speed = 22;
			AudioManager.instance.PlaySound("Phase");
			phase = true;
		}

		if (base.life <= 0)
		{
			GameObject.Find("Win Canvas").GetComponent<Canvas>().enabled = true;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<AchievementManager>().ManageAchievement("Boss");
			GameObject.FindGameObjectWithTag("Player").SetActive(false);
			phase = false;
		}
	}
}
