using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour {

    [SerializeField]
    private Score scores;

    [SerializeField]
    private Jump jump;

    [SerializeField]
    private GUIStyle labelStyle;

    void Start()
    {
        labelStyle.fontSize = 20;
        jump = GameObject.Find("Player").GetComponent<Jump>();
        scores = GetComponent<Score>();
    }

    void OnGUI()
    {
        if(jump.GetDoubleJumpIter() <= 1)
            GUI.Label(new Rect(0, 0, 200, 100),"Score: " + scores.GetScore().ToString(), labelStyle);
        else
            GUI.Label(new Rect(0, 0, 200, 100), "Score: " + scores.GetScore().ToString() + " X" + jump.GetDoubleJumpIter(), labelStyle);
    }

    public void RestartGame()
    {
        Application.LoadLevel("IceTower");
    }

    public void QuitToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
