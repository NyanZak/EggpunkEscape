using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Backup");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("credits_scene");
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("win_scene");
    }

    public void LoadEndCredits()
    {
        SceneManager.LoadScene("endcredits_scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}