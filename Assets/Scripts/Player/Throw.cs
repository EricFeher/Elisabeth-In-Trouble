using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody2D itemProto = null;
    public float speed = 1.0f;
    public Transform firePoint;

    public int itemPoolSize = 10;
    public List<Rigidbody2D> itemPool;

    private SpriteRenderer playerSprite;

	private float realTime;
    private float helpTime;
	// Start is called before the first frame update
	void Start()
	{
		realTime = Time.time;
        helpTime = realTime;
		itemPool = new List<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

        for(int i=0; i<itemPoolSize; i++) {
            Rigidbody2D itemClone = Instantiate(itemProto);
            itemClone.gameObject.SetActive(false);

            itemPool.Add(itemClone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        realTime = Time.time;
        if (playerSprite.sprite.name.Equals("Attack2_8") && helpTime+0.5<realTime)
        {
            throwItem();
            AudioManager.instance.PlaySound("Shoot");
            helpTime = realTime;
        }
    }

    void throwItem() {
        Rigidbody2D itemClone = getItemFromPool();
        itemClone.transform.position = firePoint.position;

        itemClone.gameObject.SetActive(true);
        
        float direction = CharacterMovement.facingRight ? +1 : -1;

        Vector3 force = transform.right * speed * direction;
        itemClone.velocity = force;

    }

    private Rigidbody2D getItemFromPool() {
        
        foreach(Rigidbody2D item in itemPool) {
            if(!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
}
