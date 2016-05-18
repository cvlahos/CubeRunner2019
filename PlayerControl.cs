using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	public float playerSpeed;
	public float jumpForce;
	public Rigidbody2D playerRB;

	public SpriteRenderer playerSpriteRenderer;
	bool canJump;

	public MusicManager musicManager;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	

		if (Input.GetKeyDown (KeyCode.Space) && canJump == true) 
		{
			musicManager.PlayJumpSound();
			playerRB.AddForce (new Vector2 (0, jumpForce));
		
		}
			


		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			playerRB.AddForce (new Vector2 (-playerSpeed, 0));
			//playerRB.velocity += new Vector2 (-playerSpeed * Time.deltaTime,0);
			//playerSpriteRenderer.flipX = true;
		}


		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			playerRB.AddForce (new Vector2 (playerSpeed, 0));
			//playerRB.velocity += new Vector2 (playerSpeed * Time.deltaTime,0);
			//playerSpriteRenderer.flipX = false;

		} 

	}

	//	OnTriggerEnter is called when the Collider enters the trigger.

	void OnTriggerEnter2D (Collider2D playerEnterTrigger)
	{
		if (playerEnterTrigger.gameObject.tag == "Platform") 
		{
			canJump = true;
		} 
			
	}

	//OnTriggerStay is called almost all the frames for every Collider other that is touching the trigger.
	void OnTriggerStay2D (Collider2D playerStayTrigger)
	{
		if (playerStayTrigger.gameObject.tag == "Platform") 
		{
			canJump = true;
		}
	}

	//OnTriggerExit is called when the Collider other has stopped touching the trigger.
	void OnTriggerExit2D (Collider2D playerExitTrigger)
	{
		if (playerExitTrigger.gameObject.tag == "Platform") 
		{
			canJump = false;
		}
	}


}
