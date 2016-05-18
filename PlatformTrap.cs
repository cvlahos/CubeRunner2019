using UnityEngine;
using System.Collections;

public class PlatformTrap : MonoBehaviour 
{

	public Rigidbody2D platformRB;

	public float fallDelay;

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
			
			Invoke("PlatformFall",fallDelay);
		}
	}

	void PlatformFall()
	{
		platformRB.isKinematic = false;
	}
}
