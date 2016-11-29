using UnityEngine;
using System.Collections;

public class Riser : MonoBehaviour 
{
	// take control of the platform's rigid body
	public Rigidbody2D platformRB;
	
	// need a variable for how long the platform should stay before falling
	public float riseDelay;

	public float riseSpeed;
	public float transportSpeed;

	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnCollisionStay2D(Collision2D playerCollision)
	{
		if (playerCollision.gameObject.tag == "Player") 
		{
			//Invoke the platform rise function
			Invoke("PlatformMove", riseDelay);

			
		}
	}

	void OnCollisionExit2D(Collision2D playerCollisionExit)
	{
		if (playerCollisionExit.gameObject.tag == "Player") 
		{

			platformRB.velocity = new Vector2 (0f, 0f);
			CancelInvoke();
			
		}
	}
	
	void PlatformMove()
	{

		platformRB.velocity = new Vector2 (transportSpeed, riseSpeed);
	}
}

