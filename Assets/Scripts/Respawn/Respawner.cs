using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 original_position;
    private bool original_active;

    private RespawnManager rm;

    protected virtual void Start()
    {
        GameObject.Find("Death Canvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Win Canvas").GetComponent<Canvas>().enabled = false;
        original_position = this.transform.position;
        original_active = this.gameObject.activeSelf;
        rm = GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnManager>();
        rm.register(this);
    }

    public virtual void respawn()
    {
        GameObject.Find("Death Canvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Win Canvas").GetComponent<Canvas>().enabled = false;
        this.transform.position = original_position;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        this.gameObject.SetActive(original_active);
    }
}
