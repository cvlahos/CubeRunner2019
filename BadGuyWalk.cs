using UnityEngine;
using System.Collections;

public class BadGuyWalk : MonoBehaviour 
{
	// for enemy AI;
	public Rigidbody2D badGuyRb;
	public float badGuySpeed;
	bool badGuyRight;

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
		badGuyRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (badGuyRight == true) 
		{
			badGuyRb.velocity += new Vector2 (badGuySpeed * Time.deltaTime,0);

		}

		if (badGuyRight == false) 
		{
			badGuyRb.velocity += new Vector2 (-badGuySpeed * Time.deltaTime,0);

		}


	}

	// when there is trigger collision with the RightBounds the enemey will turn around and go the other way
	// when there is trigger collision with the LeftBounds the enemey will turn around and go the other way
	// when there is a trigger collision with the bottom of the player the enemy will be destroyed and the player will points and a boost up

	void OnTriggerEnter2D (Collider2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "RightBounds") 
		{
			badGuyRight = false;
		} 


		if (enemyCollision.gameObject.tag == "LeftBounds") 
		{
			badGuyRight = true;
		} 

		if (enemyCollision.gameObject.tag == "Player") 
		{
			camCtrl.HitBadGuyCam();
			GameManager.score = GameManager.score + 20;
			musicManager.PlayJumpSound();
			musicManager.PlayEnemyDestroyedSound();
			playerRB.AddForce(new Vector2 (0,pushUpForce));
			Destroy (gameObject);
		} 

	}

	// when there is a collision with any other part of the player bad stuff will happen
	void OnCollisionEnter2D (Collision2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Player") 
		{
			levelManager.LoseChanceAndReset ();
		} 
			
	}
	

}
