﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public Transform mainMenu, optionMenu;


    public void LoadGame(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
