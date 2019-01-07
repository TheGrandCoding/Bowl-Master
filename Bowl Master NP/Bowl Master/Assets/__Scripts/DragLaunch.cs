using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour 
{
	private Ball ball;
	private Vector3 dragStart,dragEnd;
	private float startTime,endTime;

	// Use this for initialization
	void Start () 
	{
		ball = GetComponent<Ball> ();
	}

	public void DragStart()
	{
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

	public void DragEnd ()
	{
		dragEnd = Input.mousePosition;
		endTime = Time.time;

		float dragDur = endTime - startTime;

		float launchSpeedX = (dragEnd.y - dragStart.y) / dragDur * 1.5f;
		float launchSpeedZ = (dragEnd.x - dragStart.x) / dragDur * 1.5f;

		Vector3 launchVelocity = new Vector3 (launchSpeedX,0,-launchSpeedZ);
		if ( ! ball.inPlay)
		{
			ball.Launch(launchVelocity);
		}
	}

	public void MoveStart(float nudge)
	{
		if ( ! ball.inPlay)
		{
			ball.transform.Translate (new Vector3(0,0,nudge));

			float newZ = Mathf.Clamp (transform.position.z,-30f,30f);
			transform.position = new Vector3 (transform.position.x,transform.position.y,newZ);
		}


	}
}
