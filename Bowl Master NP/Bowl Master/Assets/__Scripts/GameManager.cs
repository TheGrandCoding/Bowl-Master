using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

    // Use this for initialization
    void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);
        ball.Reset();
        pinSetter.PerformAction(ActionMaster.NextAction(bowls));

        try
        {
            scoreDisplay.FillScoreCard(bowls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(bowls));
        }
        catch
        {
            Debug.Log("Sum ting wong with FillScoreCard()");
        }
        
    }
}
