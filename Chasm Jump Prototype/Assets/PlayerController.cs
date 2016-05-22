using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	private Animator animator;
	private Rigidbody2D characterRigidbody;

	private Vector2 moveVector;
	private Vector2 jumpVector;

	private float horizontalInput;

	public float accelerationSpeed;
	public float jumpHeight;
	public float jumpDistance;
	public Transform groundCheck;
	private bool grounded;

	void Start ()
	{
		animator = GetComponent<Animator>();
		characterRigidbody = GetComponent<Rigidbody2D>();
		grounded = true;
	}
	
	void Update () 
	{
		horizontalInput = Input.GetAxis("Horizontal");


		//Handles all Sprite flipping
		if (horizontalInput != 0) 
		{
			if(horizontalInput > 0) 
			{
				animator.SetLayerWeight(0, 1);
				animator.SetLayerWeight(1, 0);
			}
			else
			{
				animator.SetLayerWeight(0, 0);
				animator.SetLayerWeight(1, 1);
			}
		}

		if (grounded)
		{
			//Sprite Animation Running
			if (horizontalInput != 0)
			{
				animator.SetInteger("Movement", 1);
			}
			//Sprite Animation Idle
			else 
			{
				animator.SetInteger("Movement", 0);
			}
			//Sprite Animation Jump handled in FixedUpdate
		}
		
	}

	void FixedUpdate ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));
		Debug.Log("Grounded: " + grounded);

		DebugPanel.Log("Horizontal Input: ", horizontalInput);
		DebugPanel.Log("Is Jumping? ", animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"));

		if (!grounded)
		{
			ApplyExtraGravity();
		}
		else
		{
			//Running	
			if (horizontalInput != 0 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
			{
				moveVector = new Vector2(horizontalInput, characterRigidbody.velocity.y);
				moveVector.Normalize();
				characterRigidbody.velocity = new Vector2(moveVector.x * accelerationSpeed, moveVector.y);

				if (Input.GetButtonDown("Jump"))
				{
					Debug.Log("Run Jump");
					animator.SetTrigger("Jump");
					//Facing Right
					if (animator.GetLayerWeight(0) == 1)
					{
						characterRigidbody.AddForce(new Vector2(jumpDistance, jumpHeight), ForceMode2D.Impulse);
					}
					//Facing Left
					else
					{
						characterRigidbody.AddForce(new Vector2(-jumpDistance, jumpHeight), ForceMode2D.Impulse);
					}
				}
			}
			//Bounce Jump
			else if (Input.GetKey(KeyCode.LeftShift) && horizontalInput != 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
			{
				Debug.Log("Bounce Jump");
				//Facing Right
				if (animator.GetLayerWeight(0) == 1)
				{
					characterRigidbody.AddForce(new Vector2(jumpDistance, jumpHeight), ForceMode2D.Impulse);
				}
				//Facing Left
				else
				{
					characterRigidbody.AddForce(new Vector2(-jumpDistance, jumpHeight), ForceMode2D.Impulse);
				}
			}
			//Stationary
			else
			{
				characterRigidbody.velocity = Vector2.zero;
				
				if (Input.GetButtonDown("Jump") && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
				{
					Debug.Log("Stationary Jump");
					animator.SetTrigger("Jump");
					characterRigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
				}
			}
		}
	}

	void ApplyExtraGravity ()
	{
		characterRigidbody.AddForce(new Vector2(0, -jumpHeight/4f), ForceMode2D.Force);
	}
}
