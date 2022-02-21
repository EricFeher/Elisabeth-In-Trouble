using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    public List<Respawner> respawnObjects;

    
    void Awake()
    {
        respawnObjects = new List<Respawner>();
    }

    public void resetGame()
	{
		foreach (Respawner resp in this.respawnObjects)
		{
			resp.respawn();
		}
        GameObject.Find("BossGhost").GetComponent<BossGhostAI>().speed = 15;
    }

	public void register(Respawner resp)
    {
        this.respawnObjects.Add(resp);
    }


}
