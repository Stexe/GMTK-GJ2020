using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HudText : MonoBehaviour
{
    public int minScore = 100;
    public int secondsTimer = 120;
    public int secondScoreMultipler = 10;
    private float countdown;
    private int totalScore;
    private Text scoreText;
    private Text timerText;

    private void Start()
    {
        var texts = GetComponentsInChildren<Text>();
        timerText = texts.Single(t => t.name == "Timer");
        scoreText = texts.Single(t => t.name == "Score");
        UpdateScoreText();
        BeginTimer();
    }

    private void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        UpdateTimerText();
    }

    public void OnDelivered(Triggerable box)
    {
        totalScore += Convert.ToInt32(countdown) * secondScoreMultipler + minScore;
        UpdateScoreText();
        BeginTimer();
    }

    private void BeginTimer()
    {
        countdown = secondsTimer;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + totalScore;
    }

    private void UpdateTimerText()
    {
        int seconds = Convert.ToInt32(countdown);
        int minutes = seconds / 60;
        seconds %= 60;
        timerText.text = "Time: " + minutes + ":" + (seconds != 0 ? seconds.ToString() : "00");
    }
}
