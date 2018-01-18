using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    protected void OverGame()
    {
        PauseGame();
    }

    protected void PauseGame()
    {
        Time.timeScale = 0;
    }

    protected void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
