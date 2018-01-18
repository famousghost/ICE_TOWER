using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour {

    private Scores scores;

    void Start()
    {
        scores = GetComponent<Scores>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100),"Scores: " + scores.GetScore().ToString());
    }
}
