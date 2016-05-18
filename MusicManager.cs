using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
	public AudioClip jumpSoundClip;
	public float jumpVolume;

	public AudioClip enemyDestroyedClip;
	public float enemyDestroyedVolume;
	
	public AudioClip catapultSoundClip;
	public float catapultSoundVolume;

	public AudioClip timerSoundClip;
	public float timerSoundVolume;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PlayJumpSound()
	{
		AudioSource.PlayClipAtPoint (jumpSoundClip,transform.position,jumpVolume);
	}
	

	public void PlayEnemyDestroyedSound()
	{
		AudioSource.PlayClipAtPoint (enemyDestroyedClip,transform.position);
	}

	public void PlayCatapultSound()
	{
		AudioSource.PlayClipAtPoint (catapultSoundClip,transform.position);
	}
	public void PlayTimerSound()
	{
		AudioSource.PlayClipAtPoint (timerSoundClip,transform.position);
	}


}
