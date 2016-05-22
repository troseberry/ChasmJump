//This jump set up is for the bounce jump

//Need to have jump set up for just normal jumping that also allows the player to control flight in air, at a lower horizontal force



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
			//Sprite Animation Jump
			if (Input.GetButtonDown("Jump"))
			{
				animator.SetTrigger("Jump");
			}
		}
		
	}

	void FixedUpdate ()
	{

		grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));
		Debug.Log("Grounded: " + grounded);

		DebugPanel.Log("Horizontal Input: ", horizontalInput);

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
			//Run Jump
			//else if (Input.GetButtonDown("Jump") && horizontalInput != 0/*&& animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump")*/)
			/*{
				Debug.Log("Run Jump");
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
			}*/
			//Standing Still
			else
			{
				characterRigidbody.velocity = Vector2.zero;


				if (Input.GetButtonDown("Jump")/* && animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump")*/)
				{
					Debug.Log("Stationary Jump");
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
