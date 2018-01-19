using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField]
    private int score = 0;

    [SerializeField]
    private int currentScore = 0;

    public void AddScore(int score)
    {
        this.score += score;
        if (currentScore < 20)
            this.currentScore += score;
        else
            currentScore = 0;
    }

    public void AddScoreDoubleJump(int score,int multi)
    {
        this.score += (score * multi);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

}
