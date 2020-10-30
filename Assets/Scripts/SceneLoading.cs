using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    BannerAds bannerAds;
  public void StartGame()
    {
        SceneManager.LoadScene(1);
        bannerAds.testMode = false;
    }
}
