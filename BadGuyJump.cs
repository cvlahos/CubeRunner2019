using UnityEngine;
using System.Collections;

public class BadGuyJump : MonoBehaviour 
{

	public Rigidbody2D badGuyRb;

	public float badGuyJumpSpeed;
	public float timeBefore1stJump;
	public float timeBeforeNextJump;

	public SpriteRenderer badGuySpriteRenderer;

	public LevelManager levelManager;

	public Rigidbody2D playerRB;
	public float pushUpForce;

	public MusicManager musicManager;
	//float timer;

	public CamCtrl camCtrl;

	//public float switchDirection;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("badGuyJumpAttack",timeBefore1stJump,timeBeforeNextJump);
		//timer = badGuyJumpDuration;
	}
	
	// Update is called once per frame
	void Update ()
	{


			
	}

	void badGuyJumpAttack()
	{
		
		badGuyRb.AddForce(new Vector2 (0, badGuyJumpSpeed));
	}

	void OnCollisionEnter2D (Collision2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Player") 
		{
			levelManager.LoseChanceAndReset ();
		
		} 
	
	}

	void OnTriggerEnter2D (Collider2D enemyTrigCollision)
	{
		if (enemyTrigCollision.gameObject.tag == "Player") 
		{
			camCtrl.HitBadGuyCam();
			GameManager.score = GameManager.score + 20;
			musicManager.PlayJumpSound();
			musicManager.PlayEnemyDestroyedSound();
			playerRB.AddForce(new Vector2 (0,pushUpForce));
			Destroy(gameObject);
		} 
		
	}
	//if you want the bad guy to flip sprite
	/*
	void OnTriggerExit2D (Collider2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Platform") 
		{
			
			badGuySpriteRenderer.flipY = true;
		} 

	}

	void OnTriggerStay2D (Collider2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Platform") 
		{

			badGuySpriteRenderer.flipY = false;
		} 

	}
*/

}
