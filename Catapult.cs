using UnityEngine;
using System.Collections;

public class Catapult : MonoBehaviour 
{
	public Rigidbody2D playerRB;
	public float yForce;
	public float xForce;

	public MusicManager musicManager;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter2D (Collision2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Player") 
		{
			musicManager.PlayCatapultSound();
			playerRB.AddForce(new Vector2 (xForce,yForce));

			
		} 

	}

}
