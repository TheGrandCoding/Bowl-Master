using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{

    public int lastStanding = -1;
    public Text myText;
    public bool ballOutOfBox = false;
    public int lastSettledCount = 10;

    private float lastChangeTime;
    private int standing;
    private int pinfall;
    private GameManager gameManager;


    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = CountStanding().ToString();

        if (ballOutOfBox)
        {
            UpdateStanding();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Ball")
        {
            ballOutOfBox = true;
        }
    }

    void UpdateStanding()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStanding)
        {
            lastChangeTime = Time.time;
            lastStanding = currentStanding;
            return;
        }

        if ((Time.time - lastChangeTime) >= 3f)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        pinfall = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();

        gameManager.Bowl(pinfall);

        lastStanding = -1;
        ballOutOfBox = false;
        myText.color = Color.green;
    }

    int CountStanding()
    {
        standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
}
