using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostAI : MonoBehaviour
{
    public Rigidbody2D itemProto = null;
    public float speed = 1.0f;
	public Transform firePoint;
    public Transform player;

	public int itemPoolSize = 10;
    public List<Rigidbody2D> itemPool;

    private float realTime;
	private float helpTime;
    public bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
		realTime = Time.time;
        helpTime = realTime;
        itemPool = new List<Rigidbody2D>();

        for (int i = 0; i < itemPoolSize; i++)
        {
            Rigidbody2D itemClone = Instantiate(itemProto);
            itemClone.gameObject.SetActive(false);
            itemPool.Add(itemClone);
        }
    }

    // Update is called once per frame
    void Update()
	{
        realTime = Time.time;
        if (facingRight)
		{
			if (player.transform.position.x < this.transform.position.x)
			{
				flip();
			}
		}
		else
		{
			if (player.transform.position.x > this.transform.position.x)
			{
				flip();
			}
		}
        if (Mathf.Abs(player.transform.position.x - this.transform.position.x) < 10 && realTime-helpTime>2)
		{
			print("123");
            helpTime = realTime;
			throwItem();
        }
        
    }

    void throwItem()
    {
        Rigidbody2D itemClone = getItemFromPool();
        itemClone.transform.position = firePoint.position;

        itemClone.gameObject.SetActive(true);

        float direction = this.GetComponent<BasicGhostAI>().facingRight ? +1 : -1;

        Vector3 force = transform.right * speed * direction;
        itemClone.velocity = force;

    }

    private Rigidbody2D getItemFromPool()
    {

        foreach (Rigidbody2D item in itemPool)
        {
            if (!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
}
