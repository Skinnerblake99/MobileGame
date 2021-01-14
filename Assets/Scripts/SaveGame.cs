﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveGame : MonoBehaviour
{
    bool timetoEnd = false;
    //Standard time set to 8 minutes will be changed in inspector per level
    public float timer = 480;
    public int levelChoice;
    EZMobileBasics ez;
    WhichScene ws;
    void Start()
    {
        timetoEnd = false;
        ez = FindObjectOfType<EZMobileBasics>();
        ws = FindObjectOfType<WhichScene>();
        if(ws.Scene == 2)
        {
            levelChoice = 1;
        }
        if (ws.Scene == 3)
        {
            levelChoice = 2;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timetoEnd = true;
        }

        if(timetoEnd && levelChoice == 1)
        {
            ez.SubmitScoreLevel1();
            ez.UnlockAchievement1stLevelClear();
            SceneManager.LoadScene(2);
        }

        if (timetoEnd && levelChoice == 2)
        {
            ez.SubmitScoreLevel2();
            ez.UnlockAchievement2ndLevelClear();
        }
    }

    

}
