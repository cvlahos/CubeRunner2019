using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour 
{
	float TargetFOV;
	public float startCamDis;
	public float Speed = 1f; //Will reach target value in 1sec. 2f will make it achieve in half second (1f/2f)... and so on!
	public Rigidbody2D playerRB;
	bool zoomHit = false;
	public float zoomHitDis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (zoomHit == false) 
		{
			TargetFOV = playerRB.velocity.magnitude + startCamDis;
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,TargetFOV * 3,Speed * Time.deltaTime);
		}

		if (zoomHit == true) 
		{

			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,zoomHitDis,1 * Time.deltaTime);
		}

	
	}

	public void HitBadGuyCam()
	{
		zoomHit = true;
		Invoke ("ResetZoom",.3f);

	}

	void ResetZoom()
	{
		zoomHit = false;
	}
}
