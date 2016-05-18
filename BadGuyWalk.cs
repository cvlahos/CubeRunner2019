using UnityEngine;
using System.Collections;

public class BadGuyWalk : MonoBehaviour 
{
	public SpriteRenderer badGuySpriteRenderer;
	public Rigidbody2D badGuyRb;
	public float badGuySpeed;

	bool badGuyRight;

	public LevelManager levelManager;
	public Rigidbody2D playerRB;
	public float pushUpForce;

	public MusicManager musicManager;

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
			//badGuySpriteRenderer.flipX = false;
		}

		if (badGuyRight == false) 
		{
			badGuyRb.velocity += new Vector2 (-badGuySpeed * Time.deltaTime,0);
			//badGuySpriteRenderer.flipX = true;
		}


	}

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
			GameManager.score = GameManager.score + 20;
			musicManager.PlayJumpSound();
			musicManager.PlayEnemyDestroyedSound();
			playerRB.AddForce(new Vector2 (0,pushUpForce));
			Destroy (gameObject);
			
		} 

	}

	void OnCollisionEnter2D (Collision2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Player") 
		{
			levelManager.LoseChanceAndReset ();
			
		} 
		
		
	}



}
