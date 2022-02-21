using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
	public int life = 3;
	public Transform fallDeathCheck;
	private float untouchableTime;
	float realTime;

	private void Start()
	{
		untouchableTime = Time.time;
	}
	// Update is called once per frame
	void Update()
	{
		realTime = Time.time;
		if (transform.position.y < fallDeathCheck.position.y)
		{
			GameObject.Find("Death Canvas").GetComponent<Canvas>().enabled = true;
			AudioManager.instance.PlaySound("Death");
			GameObject.FindGameObjectWithTag("GameController").GetComponent<AchievementManager>().ManageAchievement("Map");
			this.gameObject.SetActive(false);
		}
		return;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		OnTriggerEnter2D(collision);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		print("asd");
		if (col.gameObject.tag == "Enemy" && realTime > untouchableTime + 0.7)
		{
			life--;
			print("Life:" + life);
			if (life <= 0)
			{
				AudioManager.instance.PlaySound("Death");
				GameObject.Find("Death Canvas").GetComponent<Canvas>().enabled = true;
				this.gameObject.SetActive(false);
			}
			else
			{
				AudioManager.instance.PlaySound("Hurt");
			}
			GameObject.FindGameObjectWithTag("Health").GetComponent<Text>().text = "Heatlh: " + life;
			untouchableTime = realTime;
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("EnemyWeapon") && realTime > untouchableTime + 0.7)
		{
			life-=2;
			print("Life:" + life);
			if (life <= 0)
			{
				AudioManager.instance.PlaySound("Death");
				GameObject.Find("Death Canvas").GetComponent<Canvas>().enabled = true;
				this.gameObject.SetActive(false);
			}
			else
			{
				AudioManager.instance.PlaySound("Hurt");
			}
			GameObject.FindGameObjectWithTag("Health").GetComponent<Text>().text = "Heatlh: " + life;
			untouchableTime = realTime;
		}
	}
}
