using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGhostAI : MonoBehaviour
{
	public float speed = 1f;
	public static bool facingRight = false;
	public Transform player;
	public Vector2 basicPos;
	public float before, after;
	public float realtime, helptime;
	Vector3 temp;
	void Start()
	{
		basicPos = transform.position;
		facingRight = false;
		helptime = Time.time;
		temp = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
	}

	void Update()
	{
		//34.43
		//78.06
		realtime = Time.time;
		
		if (player.position.x > 34.43 && player.position.x < 78.06)
		{
			if (realtime > helptime + 0.3)
			{
				temp = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
				helptime = realtime;
			}
			transform.position = Vector2.MoveTowards(transform.position, player.position + temp, speed * Time.deltaTime);

		}
		else
		{
			transform.position = Vector2.MoveTowards(transform.position, basicPos, speed * Time.deltaTime);
		}
		after = transform.position.x;
		if (facingRight)
		{
			if (after<before)
			{
				flip();
			}
		}
		else
		{
			if (after>before)
			{
				flip();
			}
		}
		before = transform.position.x;
	}

	private void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = this.transform.localScale;
		theScale.x *= -1;
		this.transform.localScale = theScale;
	}
}
