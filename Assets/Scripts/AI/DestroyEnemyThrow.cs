using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyThrow : MonoBehaviour
{
	private float startEnergyBall;
	private bool active = false;
	// Start is called before the first frame update
	void Start()
	{
		startEnergyBall = GetComponent<Transform>().position.x;
	}

	// Update is called once per frame
	void Update()
	{

		if (!active)
		{
			startEnergyBall = GetComponent<Transform>().position.x;
			active = true;
			print("Belepes: " + active);
		}
		float currentEnergyBall = GetComponent<Transform>().position.x;
		if (currentEnergyBall > startEnergyBall + 20 || currentEnergyBall < startEnergyBall - 20)
		{
			active = false;
			print("Kilepes: " + active);
			this.gameObject.SetActive(false);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		active = false;
		print("Kilepes: " + collision.gameObject.name);
		this.gameObject.SetActive(false);
	}

}
