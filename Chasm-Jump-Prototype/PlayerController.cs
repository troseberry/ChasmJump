using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	private Animator animator;
	private Rigidbody2D characterRigidbody;

	private Vector2 moveVector;

	private float horizontalInput;
	private string direction;
	private int movementValue;

	public float accelerationSpeed;
	public float jumpHeight;
	public float jumpDistance;
	public Transform groundCheck;
	private bool grounded;

	void Start ()
	{
		animator = GetComponent<Animator>();
		characterRigidbody = GetComponent<Rigidbody2D>();
		direction = "right";
		movementValue = 1;
		grounded = true;
	}
	
	void Update () 
	{
		horizontalInput = Input.GetAxis("Horizontal");

		if (grounded)
		{
			if (horizontalInput != 0)
			{
				direction = (horizontalInput > 0) ? "right" : "left";

				movementValue = (horizontalInput > 0) ? Mathf.CeilToInt(horizontalInput) : Mathf.FloorToInt(horizontalInput);
				animator.SetInteger("Movement", 2 * movementValue);
			}
			else
			{
				movementValue = (direction == "right") ? 1 : -1;
				animator.SetInteger("Movement", movementValue);
			}

			if (Input.GetButtonDown("Jump"))
			{
				if (direction == "right")
				{
					animator.SetTrigger("JumpRight");
				}
				else
				{
					animator.SetTrigger("JumpLeft");
				}
			}
		}
		
	}

	void FixedUpdate ()
	{

		grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));
		Debug.Log("Grounded: " + grounded);

		if (!grounded)
		{
			ApplyExtraGravity();
		}
		else
		{
			//Only Running
			if (horizontalInput != 0 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
			{
				moveVector = new Vector2(horizontalInput, characterRigidbody.velocity.y);
				moveVector.Normalize();
				characterRigidbody.velocity = new Vector2(moveVector.x * accelerationSpeed, moveVector.y);
			}
			//Run Jump
			else if (horizontalInput != 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
			{
				Debug.Log("Run Jump");
				if (direction == "right")
				{
					characterRigidbody.AddForce(new Vector2(jumpDistance, jumpHeight), ForceMode2D.Impulse);
				}
				else
				{
					characterRigidbody.AddForce(new Vector2(-jumpDistance, jumpHeight), ForceMode2D.Impulse);
				}
			}
			//Standing Still
			else
			{
				characterRigidbody.velocity = Vector2.zero;


				if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
				{
					Debug.Log("Stationary Jump");
					if (direction == "right")
					{
						characterRigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
					}
					else
					{
						characterRigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
					}
				}
			}



			/*if (Input.GetButtonDown("Jump"))
			{
				//Invoke("ApplyJump", 1.0f);

				//characterRigidbody.velocity = Vector2.zero;
				if (direction == "right")
				{
					//characterRigidbody.velocity = new Vector2(jumpDistance, jumpHeight);
					characterRigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
				}
				else
				{
					//characterRigidbody.velocity = new Vector2(-jumpDistance, jumpHeight);
					characterRigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
				}
				//ApplyExtraGravity();
			}*/
		}
	}

	void ApplyJump ()
	{
		characterRigidbody.velocity = Vector2.zero;
		if (direction == "right")
		{
			characterRigidbody.velocity = new Vector2(jumpDistance, jumpHeight);
		}
		else
		{
			characterRigidbody.velocity = new Vector2(-jumpDistance, jumpHeight);
		}

		//characterRigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
	}

	void ApplyExtraGravity ()
	{
		characterRigidbody.AddForce(new Vector2(0, -jumpHeight/4f), ForceMode2D.Force);
	}
}
