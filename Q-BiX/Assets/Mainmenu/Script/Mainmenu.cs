using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}

