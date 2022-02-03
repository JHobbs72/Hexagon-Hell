using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreCounter;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text killTimerText;

    private float seconds;
    private int minutes;
    private int hours;


    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        timerText.text = "Time: " + hours + ":" + minutes  + ": " + (int)seconds;
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        else if (minutes >= 60)
        {
            hours++;
            minutes = 0;
        }
    }

    public void updateScore(int score)
    {
        scoreCounter.text = "Score: " + score;
    }

    public void updateHealth(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void setTimeRemaining(float seconds)
    {
        killTimerText.text = string.Format("Instant Kill Time: {0:00}", seconds);
    }
}
