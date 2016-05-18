using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static int playerChances = 3;
	public static int totalCoinCount;
	public static int score;

	public Text myScore;
	public Text myChancesleft;
	public Text myTimer;

	public float timer;
	public LevelManager levelManager;

	public bool playedEndTimer;

	public MusicManager musicManager;
	

	// Use this for initialization
	void Start () 
	{
		playedEndTimer = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			levelManager.LoseChanceAndReset();
		}

		myScore.text = score.ToString ();
		myChancesleft.text = "Chances Left  " + playerChances.ToString ();
		myTimer.text = "Time Left  " + timer.ToString ();
		//Debug.Log (score);
		//Debug.Log (playerChances);


		if (playedEndTimer == false) 
		{
			if (timer <= 20f) 
			{
				musicManager.PlayTimerSound();
				playedEndTimer = true;
			}
		}

	}
}
