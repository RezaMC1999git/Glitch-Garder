using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] float damageTaken = 1f; 
    [SerializeField] float baseLives = 3f;
    float currentLives;
    Text LifeText;

    void Start()
    {
        currentLives = baseLives - PlayerPreffsController.GetDifficulty();
        LifeText = GetComponent<Text>();
        UpdateMassage();
    }
    private void UpdateMassage()
    {
        LifeText.text = currentLives.ToString();
    }
    public void DecreaseLives()
    {
        if (currentLives > 0)
        {
            currentLives -= damageTaken;
            UpdateMassage();
            if (currentLives == 0)
                FindObjectOfType<levelController>().HandleLoseCondition();
        }
       
    }
}