﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField]
    private int score = 0;

    [SerializeField]
    private int currentPlatform = 0;

    [SerializeField]
    private int multiplyPoints = 1;

    [SerializeField]
    private int platformsCounter = 0;

    public void AddScore(int score)
    {

    }

    public void AddScore(int score,int multi)
    {
        this.score += (score*multi);
        platformsCounter += 1;
        if (currentPlatform < 2)
            currentPlatform++;
        else
            currentPlatform = 0;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCurrentPlatform()
    {
        return currentPlatform;
    }

    public void AddMultiplyPoints(int multiplyPoints)
    {
        this.multiplyPoints += multiplyPoints;
    }

    public void SetMultiplyPoints(int multiplyPoints)
    {
        this.multiplyPoints = multiplyPoints;
    }

}
