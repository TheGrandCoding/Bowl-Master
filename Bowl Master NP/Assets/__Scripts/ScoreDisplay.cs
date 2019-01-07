using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreDisplay : MonoBehaviour {

    public Text[] bowlScores;
    public Text[] frameScores;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FillFrames(List<int>frames)
    {
        for (int i = 0; i < frames.Count(); i++)
        {
            frameScores[i].text = frames[i].ToString();
        }
    }

    public void FillScoreCard(List<int> rolls)
    {
        string output = FormatRolls(rolls);
        for (int i = 0; i < output.Length ; i++)
        {
            bowlScores[i].text = output.ToString();
        }
    }

    static string FormatRolls(List <int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++ )
        {
            int box = output.Length + 1;

            if (rolls[i] == 0)
            {
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10)
            {
                output += "/";
            }
            else if (box >= 19)
            {
               output += "X";
            }
            else if (rolls[i] == 10)
            {
                output += "X ";
            }
            else
            {
                output += rolls[i].ToString();
            }
        }
        
        return output;
    }
}
