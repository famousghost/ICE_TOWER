using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour {

    [SerializeField]
    private Score scores;

    [SerializeField]
    private GUIStyle labelStyle;

    void Start()
    {
        labelStyle.fontSize = 20;
        scores = GetComponent<Score>();
    }

    void OnGUI()
    {
        
        GUI.Label(new Rect(0, 0, 200, 100),"Score: " + scores.GetScore().ToString(), labelStyle);
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
