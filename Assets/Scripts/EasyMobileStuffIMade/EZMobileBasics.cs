using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;

public class EZMobileBasics : MonoBehaviour
{
    //Taken from easyMobile tutorial 11/01/2021 https://www.youtube.com/watch?v=DJjkxALQOkw
    void Awake()
    {
        if (!RuntimeManager.IsInitialized())
            RuntimeManager.Init();
    }
    void Start()
    {
        if (!GameServices.IsInitialized())
        {
            GameServices.Init();
        }
    }
    public void ShowLeaderboard()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.ShowLeaderboardUI();
        }
    }

    public void ShowAchievement()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.ShowAchievementsUI();
        }
    }

    public void SubmitScore()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.ReportScore(100, EM_GameServicesConstants.Leaderboard_testLeaderboard);
        }
    }

    public void LoadLocalUserScore()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.LoadLocalUserScore(EM_GameServicesConstants.Leaderboard_testLeaderboard, OnLocalUserScoreLoaded);
        }
    }

    void OnLocalUserScoreLoaded(string leaderboardName, UnityEngine.SocialPlatforms.IScore score)
    {
        if (score != null)
        {
            //Can add unity type of Text to = this to display in game
            Debug.Log("Your score is:" + score.value);
        }
        else
        {
            Debug.Log("No score to post on leaderboard" + leaderboardName);
        }

    }

    public void UnlockAchievement()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_testAchievements);
        }
    }
}
