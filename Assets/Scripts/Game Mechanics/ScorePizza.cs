using System.Collections;
using System.Collections.Generic;
using Game_Mechanics;
using UnityEngine;
using TMPro;

public class ScorePizza : MonoBehaviour
{
    public FinishLevel level;

    [Header("Score Count")] 
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private bool scoreUpdated;
    [Header("Shots")] [SerializeField] private int shot;
    [SerializeField] private TextMeshProUGUI shotText;
    [Header("Timer")] [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        UpdateTime();

        if (level.levelDone)
        {
            if (scoreUpdated == false)
            {
                UpdateScore((int)time);
                UpdateScore(10);
                UpdateScore(-shot);
                scoreUpdated = true;
            }
        }
    }

    public void UpdateShots(int amount)
    {
        // How many shots it taken them to finish the level
        score += amount;
        scoreText.text = score + " Pizzas";
    }

    private void UpdateTime()
    {
        if (time <= 0)
        {
            time = 0f;
        }
        else
        {
            time = time -= Time.deltaTime;
            timeText.text = time.ToString("0");
        }
    }

    private void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "You achieved a score of " + score;
    }
}