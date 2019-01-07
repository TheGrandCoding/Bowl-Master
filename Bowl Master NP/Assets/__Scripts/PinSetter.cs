using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{ 
	public Transform pinSet;
	private Pin pin; 
	private Ball ball;
    private PinCounter pinCounter;
    private Animator anim;

    // Use this for initialization
    void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball> ();
		pin = GameObject.FindObjectOfType<Pin> ();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.GetComponent<Pin> ()) 
		{
			Destroy (col.gameObject);
        }

        if (col.gameObject.GetComponent<Ball>())
        {
            ball.bounced = false;
        }
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<Ball> ()) 
		{
			pinCounter.ballOutOfBox = true;
			pinCounter.myText.color = Color.red;
		}
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
        ball.inPlay = false;
    }

	public void RaisePins()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
		{
			pin.Raise ();
        }

	}

    public void RenewPins()
    {
        Instantiate(pinSet , new Vector3 (1829f , 30f , 0f) , Quaternion.identity);
        ball.inPlay = false;
    }

    public void PerformAction(ActionMaster.Action action)
    {
        Debug.Log(action);

        if (action == ActionMaster.Action.Tidy)
        {
            ball.inPlay = true;
            anim.SetTrigger("tidyTrig");
        }
        else if ((action == ActionMaster.Action.EndTurn) || (action == ActionMaster.Action.Reset))
        {
            ball.inPlay = true;
            anim.SetTrigger("resetTrig");
            pinCounter.lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Dunno what to do");
        }
    }
}


