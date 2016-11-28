using UnityEngine;
using System.Collections;

public class PlatformTrap : MonoBehaviour 
{
	// take control of the platform's rigid body
	public Rigidbody2D platformRB;

	// need a variable for how long the platform should stay before falling
	public float fallDelay;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter2D(Collision2D playerCollision)
	{
		if (playerCollision.gameObject.tag == "Player") 
		{
			//Invoke the platform fall function
			Invoke("PlatformFall", fallDelay);

		}
	}

	void PlatformFall()
	{
		// take over the Is Kinematic Bool checkbox so Is Kinematic is set to false. Then gravity will cause the platform to fall
		platformRB.isKinematic = false;
	}
}
