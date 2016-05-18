using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public GameManager gameManager;
	public RectTransform recTransform;

	// Use this for initialization
	void Start()
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (gameManager.playedEndTimer == true) 
		{
			recTransform.Translate(0,-15.3f * Time.deltaTime,0);
			recTransform.localScale = new Vector3 (2,2,0);

		}


	}
}
