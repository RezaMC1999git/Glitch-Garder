﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 1f;
    [SerializeField] float defaultDifficulty = 1f;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPreffsController.GetMasterVolume();
        difficultySlider.value = PlayerPreffsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) 
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }
    public void SaveAndExit()
    {
        PlayerPreffsController.SetMasterVolume(volumeSlider.value);
        PlayerPreffsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<Level>().LoadStartMenu();
    }
    public void SetDeffaults() 
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
