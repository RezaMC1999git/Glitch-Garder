using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    Text stars;
    [SerializeField]int currentStars=1000;
    void Start()
    {
        stars = GetComponent<Text>();
        UpdateMassage();
    }
    private void UpdateMassage()
    {
        stars.text = currentStars.ToString();
    }
    public void AddStars(int amount) 
    {
        currentStars += amount;
        UpdateMassage();
    }
    public bool HaveEnoughStar(int amount) 
    {
        return currentStars >= amount;
    }
    public void SpendStars(int amount)
    {
        if (currentStars>=amount) 
        {
            currentStars -= amount;
            UpdateMassage();
        }
    }
}
