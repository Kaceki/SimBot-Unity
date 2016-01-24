using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool infoOpen;
    public GameObject Canvas_PauseMenu;
    void Start()
    {
        infoOpen = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (infoOpen == false)
            {
                Canvas_PauseMenu.SetActive(true);
                infoOpen = true;
            }
            else
            {
                Canvas_PauseMenu.SetActive(false);
                infoOpen = false;
            }
        }
    }
    public void Resume()
    {
        Canvas_PauseMenu.SetActive(false);
        infoOpen = false;
    }
    public void LoadGame(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
