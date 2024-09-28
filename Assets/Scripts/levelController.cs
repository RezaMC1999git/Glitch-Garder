using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject loseLable;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    private void Start()
    {
        winLable.SetActive(false);
        loseLable.SetActive(false);
    }
    public void AttackerSpawn() 
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <=0 && levelTimerFinished) 
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void LevelTimerFinished() 
    {
        levelTimerFinished = true;
        StopSpawners();
    }
    IEnumerator HandleWinCondition() 
    {
        winLable.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        int currnetScene = FindObjectOfType<Level>().IndexShow();
        if (currnetScene == 6 || currnetScene == 7)
            FindObjectOfType<Level>().LoadStartMenu();
        else
            FindObjectOfType<Level>().LoadNextScene();
    }
    public void HandleLoseCondition() 
    {
        loseLable.SetActive(true);
        Time.timeScale = 0;
    }
    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spw in spawners) 
        {
            spw.StopSpwan();
        }
    }
}
