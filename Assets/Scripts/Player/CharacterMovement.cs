using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float speed = 1f;
	public float jumpForce = 1f;

	public static bool facingRight = true;

	private Rigidbody2D rb;
	private Animator anim;

	public Camera cam;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public ParticleSystem dust;
	public ParticleSystem teleport;
	bool grounded;

	private float jumpHelpTime, attackHelpTime, teleportHelpTime;
	void Start()
	{
		//  Look the rigidbody2D up.
		rb = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
		jumpHelpTime = Time.time;
		attackHelpTime = Time.time;
		teleportHelpTime = Time.time;
		facingRight = true;
	}

	void Update()
	{

		float horiz = Input.GetAxis("Horizontal");
		float realTime = Time.time;

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Grounded", grounded);

		Vector2 old_v = rb.velocity;
		old_v.x = speed * horiz;
		rb.velocity = old_v;

		if (facingRight && horiz < 0)
		{
			flip();
		}
		else if (!facingRight && horiz > 0)
		{
			flip();
		}

		anim.SetFloat("Speed", Mathf.Abs(this.rb.velocity.x));


		if (grounded && jumpHelpTime + 0.1 < realTime)
		{
			anim.SetBool("Jump", false);
		}

		if (Input.GetButtonDown("Jump") && grounded)
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<AchievementManager>().ManageAchievement("Jump");
			createDust();
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			anim.SetBool("Jump", true);
			grounded = false;
			anim.SetBool("Grounded", grounded);
			jumpHelpTime = realTime;

		}

		anim.ResetTrigger("Attack");

		if (Input.GetKey(KeyCode.Mouse0) && grounded && attackHelpTime + 1 < realTime)
		{
			anim.SetTrigger("Attack");
			attackHelpTime = realTime;
		}
		if (transform.position.x > 34.43 && transform.position.x < 78.06)
		{
			if (Input.GetKeyDown("1") && realTime - teleportHelpTime > 0.5)
			{
				transform.position = new Vector3(40.65f, 0.3715615f, 0);
				cam.GetComponent<SmoothCamera>().offset = new Vector3(0, 0, 10);
				cam.GetComponent<SmoothCamera>().transform.position = new Vector3(40.65f, 0.3715615f, -10);
				teleportHelpTime = realTime;
				teleport.Play();
				AudioManager.instance.PlaySound("Teleport");
			}

			if (Input.GetKeyDown("2") && realTime - teleportHelpTime > 0.5)
			{
				transform.position = new Vector3(56.14f, -0.9118822f, 0);
				cam.GetComponent<SmoothCamera>().offset = new Vector3(0, 0, 10);
				cam.GetComponent<SmoothCamera>().transform.position = new Vector3(56.14f, -0.9118822f, -10);
				teleportHelpTime = realTime;
				teleport.Play();
				AudioManager.instance.PlaySound("Teleport");
			}

			if (Input.GetKeyDown("3") && realTime - teleportHelpTime > 0.5)
			{
				transform.position = new Vector3(71.74f, 0.8957555f, 0);
				cam.GetComponent<SmoothCamera>().offset = new Vector3(0, 0, 10);
				cam.GetComponent<SmoothCamera>().transform.position = new Vector3(71.74f, 0.8957555f, -10);
				teleportHelpTime = realTime;
				teleport.Play();
				AudioManager.instance.PlaySound("Teleport");
			}

		}


	}

	private void flip()
	{
		facingRight = !facingRight;
		if (grounded)
		{
			createDust();
		}
		Vector3 theScale = this.transform.localScale;
		theScale.x *= -1;
		this.transform.localScale = theScale;
	}

	private void createDust()
	{
		dust.Play();
	}
}
