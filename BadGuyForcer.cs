using UnityEngine;
using System.Collections;

public class BadGuyForcer : MonoBehaviour 
{

public SpriteRenderer badGuySpriteRenderer;
public Rigidbody2D badGuyRb;
public float badGuySpeed;

	public Rigidbody2D playerRB;
	public float badGuyForce;

bool badGuyRight;

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

}

	void OnCollisionEnter2D (Collision2D enemyCollision)
	{
		if (enemyCollision.gameObject.tag == "Player" && badGuyRight == true) 
		{
			playerRB.AddForce (new Vector2 (0f, 0f));
		}

		if (enemyCollision.gameObject.tag == "Player" && badGuyRight == false) 
		{
			playerRB.AddForce (new Vector2 (-0f, 0f));
		}
	}

}
