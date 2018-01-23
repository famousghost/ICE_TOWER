using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private Canvas pauseCanvas;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private KeyInput keyInput;

    [SerializeField]
    private GameObject scoreMenu;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        keyInput = GameObject.Find("Player").GetComponent<KeyInput>();
        pauseCanvas = GetComponent<Canvas>();
        scoreText.text = PlayerPrefs.GetInt("PlayerScore").ToString();
    }

    public void PauseGame()
    {
        if(keyInput.GetPauseGameValue())
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
        }
    }

    public void ResumeGame()
    {
        if (!keyInput.GetPauseGameValue())
        {
            pauseMenu.SetActive(true);
            scoreMenu.SetActive(false);
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
        }
    }

    void Update()
    {
        AcitvePauseMenuByEscape();
    }

    public void AcitvePauseMenuByEscape()
    {
        PauseGame();
        ResumeGame();
    }

    public void ActiveScoreMenu()
    {
        pauseMenu.SetActive(false);
        scoreMenu.SetActive(true);
    }

    public void ActivePauseMenu()
    {
        pauseMenu.SetActive(true);
        scoreMenu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
