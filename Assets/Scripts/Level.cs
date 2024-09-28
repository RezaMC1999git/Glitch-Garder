using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
            StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime() 
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    public int IndexShow() 
    {
        return currentScene;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene +1);
    }
    public void LoadInfinityMode()
    {
        SceneManager.LoadScene("Infinity Level");
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }
    public void LoadStartMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
