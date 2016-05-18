using UnityEngine;
using System.Collections;

public class LoseBox : MonoBehaviour 
{
	public LevelManager levelManager;
	public GameManager gameManager;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D loseTrigger)
	{
		if (loseTrigger.gameObject.tag == "Player") 
		{
			levelManager.LoseChanceAndReset ();
		
		} 
	
	}




}
