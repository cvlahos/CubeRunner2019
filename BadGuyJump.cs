using UnityEngine;
using System.Collections;

public class BadGuyJump : MonoBehaviour 
{

	// for enemy AI;
	public Rigidbody2D badGuyRb;
	public float badGuyJumpSpeed;
	public float timeBefore1stJump;
	public float timeBeforeNextJump;
	

	//need to access the level manager to reset the leve when the player is beat
	public LevelManager levelManager;

	// if the player lands on the enemy then the player will destroy the enemy and get a boost up in the air
	public Rigidbody2D playerRB;
	public float pushUpForce;

	public MusicManager musicManager;


	//don't worry about the camera
	public CamCtrl camCtrl;



	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("badGuyJumpAttack",timeBefore1stJump,timeBeforeNextJump);

	}
	
	// Update is called once per frame
	void Update ()
	{


			
	}

	void badGuyJumpAttack()
	{

		badGuyRb.AddForce(new Vector2 (0, badGuyJumpSpeed));
	}

	// when there is a collision with any other part of the player bad stuff will happen
	void OnCollisionEnter2D (Collision2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Player") 
		{
			levelManager.LoseChanceAndReset ();
		
		} 
	
	}


	// when there is a trigger collision with the bottom of the player the enemy will be destroyed and the player will get points and a boost up
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


}
