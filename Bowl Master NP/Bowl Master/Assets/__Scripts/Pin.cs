using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	private Rigidbody myRigidbody;
	private bool moving = false;
	private Vector3 pos = new Vector3(270f,0f,0f);
    private GameObject bowlingPins;
    private AudioSource audioSource; 

	// Use this for initialization
	void Start () 
	{
        audioSource = GetComponent<AudioSource>();
		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 rotationInEuler = transform.eulerAngles;

		if (moving)
		{
			transform.eulerAngles = pos;
		}
	}

	public bool IsStanding()
	{
		float tiltInX = Mathf.Abs(transform.eulerAngles.x);

		if (( 269f < tiltInX && tiltInX < 280f ) || (260f < tiltInX && tiltInX < 269f)) 
		{
			return true;
		} 
		return false;
	}

	public void Raise()
	{
		if (IsStanding ()) 
		{
			myRigidbody.useGravity = false;
			transform.Translate(new Vector3(0f,40f,0f), Space.World);
            moving = true;
		}
	}

	public void Lower()
	{
        transform.Translate(new Vector3(0f, -40f, 0f), Space.World);
        myRigidbody.useGravity = true;
        moving = false;                
	}
}
