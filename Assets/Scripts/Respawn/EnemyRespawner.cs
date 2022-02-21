using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : Respawner
{
    public int original_life;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        original_life = this.GetComponent<EnemyDestroy>().life;
    }

    public override void respawn() {
        base.respawn();
        this.GetComponent<EnemyDestroy>().life = original_life;
    }
}
