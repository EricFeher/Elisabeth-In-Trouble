using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyDestroy : EnemyDestroy
{
	public static int deaths = 0;

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
	}

	public override void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
	}
}
