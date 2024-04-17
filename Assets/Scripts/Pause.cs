using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausedButton;
    [SerializeField] private GameObject PausedMenu;
    public void Paused()
    {
        Time.timeScale = 0f;
        PausedButton.SetActive(false);
        PausedMenu.SetActive(true);
    }

    public void Resume() 
    {
        Time.timeScale = 1f;
         PausedButton.SetActive(true);
        PausedMenu.SetActive(false);

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
