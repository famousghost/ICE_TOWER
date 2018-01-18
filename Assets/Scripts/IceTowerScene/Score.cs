using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int score = 0;

    void Update()
    {

    }

    public void AddScore(int scores)
    {
        this.score += scores;
    }

    public int GetScore()
    {
        return score;
    }

}
