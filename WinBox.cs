using UnityEngine;
using System.Collections;

public class WinBox : MonoBehaviour 
{
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D winBox)
		
	{

		if (winBox.gameObject.tag == "Player") 
		{
			levelManager.NextLevelToLoad ();
		}

		//use below to only reach next level after collecting all coins and reaching the goal
		/*
		if (GameManager.totalCoinCount <= 0) 
		{
			levelManager.NextLevelToLoad ();
		}
*/
		//Debug.Log ("Win trigger");
	}
}
