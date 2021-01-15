using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;

public class EZMobileBasics : MonoBehaviour
{
    ScoreManager scoremanager;
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
        scoremanager = FindObjectOfType<ScoreManager>();
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

    public void SubmitScoreLevel1()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.ReportScore(100, EM_GameServicesConstants.Leaderboard_Lv1LeaderBoard);
        }
    }

    public void LoadLocalUserScoreLevel1()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.LoadLocalUserScore(EM_GameServicesConstants.Leaderboard_Lv1LeaderBoard, OnLocalUserScoreLoaded);
        }
    }

    void OnLocalUserScoreLoaded(string leaderboardName,UnityEngine.SocialPlatforms.IScore score)
    {
        if (score != null)
        {

            //Can add unity type of Text to = this to display in game
            //score = scoremanager.S
            score.value = scoremanager.ScoreNew;
            Debug.Log("Your score is:" + score.value);
        }
        else
        {
            Debug.Log("No score to post on leaderboard" + leaderboardName);
        }

    }

    public void SubmitScoreLevel2()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.ReportScore(100, EM_GameServicesConstants.Leaderboard_Lv2LeaderBoard);
        }
    }

    public void LoadLocalUserScoreLevel2()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.LoadLocalUserScore(EM_GameServicesConstants.Leaderboard_Lv2LeaderBoard, OnLocalUserScoreLoaded);
        }
    }

    public void UnlockAchievement1stLevelClear()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_1stLevelClear);
        }
    }

    public void UnlockAchievement2ndLevelClear()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_2ndLevelClear);
        }
    }

    public void UnlockAchievement5GBrainFried()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_5GBrainFried);
        }
    }

    public void UnlockAchievementBeatenTheBug()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_BeatenTheBug);
        }
    }

    public void UnlockAchievementCovidBuster()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_CovidBuster);
        }
    }

    public void UnlockAchievementDomGottaGo()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_DomGottaGo);
        }
    }

    public void UnlockAchievementDontFeedTheKids()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_DontFeedTheKids);
        }
    }

    public void UnlockAchievementDUMPFFIGHT()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_DUMPFFIGHT);
        }
    }

    public void UnlockAchievementEatOutToNotHelpOut()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_EatOutToNotHelpOut);
        }
    }

    public void UnlockAchievementExcelFailure()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_ExcelFailure);
        }
    }

    public void UnlockAchievementEyetest()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_Eyetest);
        }
    }

    public void UnlockAchievementGoodbyeGrades()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_GoodbyeGrades);
        }
    }

    public void UnlockAchievementShakeHands()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_HospitalShakeHands);
        }
    }

    public void UnlockAchievementNoTraceNoIsolate()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_NoTraceNoIsolate);
        }
    }

    public void UnlockAchievementPressBeater()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_PressBeater);
        }
    }

    public void UnlockAchievementProtectTheCapitolBuilding()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_ProtectedTheCapitolBuilding);
        }
    }

    public void UnlockAchievementSendTheKidsBack()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_SendTheKidsBack);
        }
    }
}
