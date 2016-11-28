using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	public float playerSpeed;
	public float jumpForce;
	public Rigidbody2D playerRB;


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
		
		}


		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			playerRB.AddForce (new Vector2 (playerSpeed, 0));


		} 

	}

	//	When the bottom of the player first touches a platform the player will be able to jump

	void OnTriggerEnter2D (Collider2D playerEnterTrigger)
	{
		if (playerEnterTrigger.gameObject.tag == "Platform") 
		{
			canJump = true;
		} 
			
	}

	//OnTriggerStay is called almost all the frames the player is in contact with a platform. Player can still jump
	void OnTriggerStay2D (Collider2D playerStayTrigger)
	{
		if (playerStayTrigger.gameObject.tag == "Platform") 
		{
			canJump = true;
		}
	}

	//OnTriggerExit is called when the Collider has stopped touching the trigger. So when the player is up in the air jumping will be disabled to prevent 
	//the player from flying accross the level
	void OnTriggerExit2D (Collider2D playerExitTrigger)
	{
		if (playerExitTrigger.gameObject.tag == "Platform") 
		{
			canJump = false;
		}
	}


}
