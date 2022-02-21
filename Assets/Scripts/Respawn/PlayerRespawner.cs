using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawner : Respawner
{
    public int original_life;

    // Start is called before the first frame update
    protected override void Start()
	{
		base.Start();
        this.gameObject.SetActive(true);
        original_life = this.GetComponent<PlayerHurt>().life;
        GameObject.FindGameObjectWithTag("Health").GetComponent<Text>().text = "Health: " + original_life;
    }

    public override void respawn()
	{
		base.respawn();
        this.gameObject.SetActive(true);
        this.GetComponent<PlayerHurt>().life = original_life;
        GameObject.FindGameObjectWithTag("Health").GetComponent<Text>().text = "Health: " + original_life;
    }

}
