using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Ball ball;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball> ();
		offset = ball.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (ball.transform.position.x <= 1800f)
        {
            this.transform.position = ball.transform.position - offset;
        }
	}
}
