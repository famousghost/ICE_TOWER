using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGUI : MonoBehaviour {

    [SerializeField]
    private GameObject infoMenu;

    [SerializeField]
    private GameObject mainMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    public void InfoShow()
    {
        infoMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IceTower");
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
